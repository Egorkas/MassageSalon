using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class VisitorsController : BaseController
    {
        private readonly IVisitorService _service;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VisitorsController(IVisitorService service, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                var visitor = _service.GetAll();
                Logger.LogInformation("Admin get all visitors");
                return View(_mapper.Map<IEnumerable<VisitorModel>>(visitor));
            }
            else
            {
                Logger.LogInformation("Visitor in role visitor get information");
                var login = _httpContextAccessor.HttpContext.User.Identity.Name;
                var visitor = _service.Get(x => x.Login == login);
                var list = new List<Visitor>();
                list.Add(visitor);
                return View(_mapper.Map<IEnumerable<VisitorModel>>(list));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Edit(int id)
        {
            var visitor = _service.GetById(id);

            if (visitor == null)
                return NotFound();
            return View(_mapper.Map<VisitorModel>(visitor));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Edit(VisitorModel visitor)
        {
            if (ModelState.IsValid)
            {
                var visitorId = _service.Get(v => v.Login == visitor.Login).Id;
                if (visitorId == 0)
                {
                    _service.Update(_mapper.Map<Visitor>(visitor));
                    return RedirectToAction("Index");
                }
                visitor.Id = visitorId;
                _service.Update(_mapper.Map<Visitor>(visitor));
                return RedirectToAction("Index");
            }
            Logger.LogError("Model isn't valid");
            return View(visitor);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            if (_service.GetById(id).RoleId == 1)
            {
                return RedirectToAction("Index");
            }
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
