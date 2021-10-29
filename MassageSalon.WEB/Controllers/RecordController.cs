using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Filters;
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
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        public RecordController(IMasseurService masseurService, IRecordService recordService
                                , IMapper mapper,IVisitorService visitorService
                                , IOfferService offerService, IHttpContextAccessor httpContextAccessor)
        {
            _masseurService = masseurService;
            _recordService = recordService;
            _visitorService = visitorService;
            _offerService = offerService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Title"] = "Records";
            if (User.IsInRole("admin"))
            {
                var allRecords = _recordService.GetWithInclude();
                return View(_mapper.Map<IEnumerable<Record>, IEnumerable<RecordModel>>(allRecords));
            }
            
            var records = _recordService.GetWithInclude().Where(x => x.Visitor.Login == User.Identity.Name);
            return View(_mapper.Map<IEnumerable<Record>, IEnumerable<RecordModel>>(records));
        }

        [HttpGet]
        public async Task<IActionResult> CreateRecord()
        {
            ViewData["Title"] = "Record";
            var masseurs = await _masseurService.GetAllAsync();
            var offers = await _offerService.GetAllAsync();
            ViewData["Masseurs"] = _mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs);
            ViewData["Offers"] = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferModel>>(offers);
            return View();
        }
        [HttpPost]
        [CustomExceptionFilter]
        public async Task<IActionResult> CreateRecord(RecordModel recordModel)
        {

            if (!ModelState.IsValid)
            {
                Logger.LogInformation("Model isn't valid");
                return View(recordModel);
            }

            var existRecord = _recordService.IsExists(recordModel.MasseurId, recordModel.TimeRecord);
            if (existRecord != null)
            {
                Logger.LogInformation("Model isn't valid");
                ViewData["Title"] = "Sorry, this record exist";
                var masseurs = await _masseurService.GetAllAsync();
                var offers = await _offerService.GetAllAsync();
                ViewData["Masseurs"] = _mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs);
                ViewData["Offers"] = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferModel>>(offers);
                return View(recordModel);
            }
            var visitor = _visitorService.Get(x => x.Login == User.Identity.Name).Id;
            
            var record = new RecordModel()
            {
                TimeRecord = recordModel.TimeRecord,
                MasseurId = recordModel.MasseurId,
                VisitorId = visitor,
                OfferId = recordModel.OfferId,
                Detail = recordModel.Detail
            };

            await _recordService.CreateAsync(_mapper.Map<Record>(record));
            return RedirectToAction("Index");
        }
    }
}
