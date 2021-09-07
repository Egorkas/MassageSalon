using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using MassageSalon.WEB.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MassageSalon.WEB.Controllers
{
    public class RecordController : Controller
    {
        private readonly IMasseurService _masseurService;
        private readonly IRecordService _recordService;
        private readonly IMapper _mapper;
        public RecordController(IMasseurService masseurService, IRecordService recordService, IMapper mapper)
        {
            _masseurService = masseurService;
            _recordService = recordService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var masseurs = _masseurService.GetAll();
            return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs));
        }
        [HttpPost]
        public IActionResult Index(int masseurId, DateTime date)
        {
            var barbers = _masseurService.GetAll();
            var result = _recordService.IsExists(masseurId, date);
            if (result != null)
            {
                ViewBag.Message = "Sorry, this record exist";
                return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(barbers));
            }

            var masseur = _masseurService.GetById(masseurId);

            var record = new Record()
            {
                MasseurId = masseurId,
                Masseur = masseur,
                TimeRecord = date,
            };

            var validator = new RecordIsBusyValidator();
            var validationResult = validator.Validate(record);
            if (!validationResult.IsValid)
            {
                ViewBag.Message = validationResult.Errors.First().ToString();
                return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(barbers));
            }

            _recordService.Create(record);
            return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(barbers));
        }
    }
}
