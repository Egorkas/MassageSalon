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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class RecordController : BaseController
    {
        private readonly IMasseurService _masseurService;
        private readonly IRecordService _recordService;
        private readonly IVisitorService _visitorService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public RecordController(IMasseurService masseurService, IRecordService recordService, IMapper mapper,IVisitorService visitorService, IHttpContextAccessor httpContextAccessor)
        {
            _masseurService = masseurService;
            _recordService = recordService;
            _visitorService = visitorService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var records = _recordService.GetWithInclude();
            return View(_mapper.Map<IEnumerable<Record>, IEnumerable<RecordModel>>(records));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateRecord()
        {
            var masseurs = _masseurService.GetAll();
            ViewBag.Masseurs = new SelectList(_mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateRecord(RecordModel recordModel)
        {

            if (!ModelState.IsValid)
            {
                Logger.LogInformation("Model isn't valid");
                return View();
            }

            var existRecord = _recordService.IsExists(recordModel.MasseurId, recordModel.TimeRecord);
            if (existRecord != null)
            {
                Logger.LogInformation("Model isn't valid");
                ViewBag.Message = "Sorry, this record exist";
                return View();
            }
            var login = _httpContextAccessor.HttpContext.User.Identity.Name;
            var visitor = _visitorService.Get(x => x.Login == login);
            
            var record = new RecordModel()
            {
                TimeRecord = recordModel.TimeRecord,
                MasseurId = recordModel.MasseurId,
                VisitorId = visitor.Id,
                Detail = recordModel.Detail
            };

            _recordService.Create(_mapper.Map<Record>(record));
            return RedirectToAction("Index");
        }
    }
}
