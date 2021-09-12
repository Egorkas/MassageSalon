using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using MassageSalon.WEB.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        //public IActionResult Index()
        //{
        //    var masseurs = _masseurService.GetAll();
        //    return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs));
        //}
        public ActionResult Index()
        {
            var records = _recordService.GetAll();
            return View(records);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateRecord()
        {
            var masseurs = _masseurService.GetAll();
            return View(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateRecord(int masseurId, DateTime date)
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

        //public ActionResult Create(int id)
        //{
        //    var viewModel = new RecordModel
        //    {
        //        VisitorId = id,
        //        MasseurId = _masseurService.GetAll().FirstOrDefault().Id

        //    };
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(RecordModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        viewModel.Masseur = _masseurService.GetAll().First();
        //        return View(viewModel);

        //    }
        //    var appointment = new Record()
        //    {
        //        TimeRecord = viewModel.TimeRecord,
        //        Detail = viewModel.Detail,
        //        Status = false,
        //        VisitorId = viewModel.VisitorId,
        //        Masseur = _masseurService.Get(x => x.Name == viewModel.Masseur.Name)

        //    };
        //    //Check if the slot is available
        //    //if (_unitOfWork.Appointments.ValidateAppointment(appointment.StartDateTime, viewModel.Doctor))
        //    //    return View("InvalidAppointment");

        //    //_unitOfWork.Appointments.Add(appointment);
        //    //_unitOfWork.Complete();
        //    return RedirectToAction("Index", "Record");
        //}
    }
}
