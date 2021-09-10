using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class VisitorsController : Controller
    {
        private readonly IVisitorService _service;
        private readonly IMapper _mapper;

        public VisitorsController(IVisitorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            var visitor = _service.GetAll();
            return View(_mapper.Map<IEnumerable<VisitorModel>>(visitor));
        }

        [Authorize(Roles = "user")]
        public IActionResult Index(int id)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var visitor = _service.Get(x => x.Name.Equals(currentUserID));
            return View(_mapper.Map<IEnumerable<VisitorModel>>(visitor));
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
        [Authorize(Roles = "admin")]
        public IActionResult Edit(VisitorModel visitor)
        {
            if (ModelState.IsValid)
            {
                _service.Create(_mapper.Map<Visitor>(visitor));
                return RedirectToAction("Index");
            }

            return View(visitor);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
