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
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("admin"))
            {
                var visitor = await _service.GetAllAsync();
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
        public async  Task<IActionResult> Edit(int id)
        {
            var visitor = await _service.GetByIdAsync(id);
            return View(_mapper.Map<VisitorModel>(visitor));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(VisitorModel visitor)
        {
            try
            {
                Logger.LogInformation($"Get request for edit visitor with Login {visitor.Login}");
                if (ModelState.IsValid)
                {
                    visitor.Id = _service.Get(x => x.Login == visitor.Login).Id;
                    await _service.UpdateAsync(_mapper.Map<Visitor>(visitor));
                    return RedirectToAction("Index");
                }
                return View(visitor);
            }catch(Exception e)
            {
                Logger.LogError($"Error to edit visitor with Login {visitor.Login}. " +
                                $"Exception message: {e.Message}");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var visitor = await _service.GetByIdAsync(id);
            if (visitor.RoleId == 1)
            {
                Logger.LogInformation("Can't delete visitor with admin rules");
                return RedirectToAction("Index");
            }
            await _service.DeleteAsync(id);
            Logger.LogInformation($"Visitor with id = {id} has been deleted!");
            return RedirectToAction("Index");
        }
    }
}
