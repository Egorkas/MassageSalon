using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
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
        public IActionResult Index()
        {
            var visitor = _service.GetAll();
            return View(_mapper.Map<IEnumerable<VisitorModel>>(visitor));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var visitor = _service.GetById(id);

            if (visitor == null)
                return NotFound();
            return View(_mapper.Map<VisitorModel>(visitor));
        }

        [HttpPost]
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
        public IActionResult Delete(int id)
        {
            
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
