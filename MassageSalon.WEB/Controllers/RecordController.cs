using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.EmailSender;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Filters;
using MassageSalon.WEB.Models;
using MassageSalon.WEB.Models.PageModel;
using MassageSalon.WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IEmailService _mail;
        public RecordController(IMasseurService masseurService, IRecordService recordService
                                , IMapper mapper,IVisitorService visitorService
                                , IOfferService offerService, IHttpContextAccessor httpContextAccessor, IEmailService mail)
        {
            _masseurService = masseurService;
            _recordService = recordService;
            _visitorService = visitorService;
            _offerService = offerService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _mail = mail;
        }
        [HttpGet]
        public ActionResult Index(int pageSize = 5, int page = 0)
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
            var visitor = _visitorService.Get(x => x.Login == User.Identity.Name);
            
            var record = new RecordModel()
            {
                TimeRecord = recordModel.TimeRecord,
                MasseurId = recordModel.MasseurId,
                VisitorId = visitor.Id,
                OfferId = recordModel.OfferId,
                Detail = recordModel.Detail
            };

            await _recordService.CreateAsync(_mapper.Map<Record>(record));
            await _mail.SendEmailAsync(visitor.Login, "Record to Massage", visitor.Name, recordModel.TimeRecord.ToString());
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult AdvancedSearch()
        {
            var guest = User.Identity.Name;
            Logger.LogInformation($"Get request to records advanced searc by {guest}");
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public async  Task<IActionResult> AdvancedSearch(RecordAdvSearchModel searchModel)
            {
            var records = _mapper.Map<IEnumerable<Record>, IEnumerable<RecordModel>>(_recordService.AdvancedSearch(
                searchModel.MasseurName,
                searchModel.MinDate,
                searchModel.MaxDate
                ));
            foreach (var item in records)
            {
                item.Masseur = _mapper.Map<Masseur, MasseurModel>(await _masseurService.GetByIdAsync(item.MasseurId));
                item.Offer = _mapper.Map<Offer, OfferModel>(await _offerService.GetByIdAsync(item.OfferId));
                item.Visitor = _mapper.Map<Visitor, VisitorModel>(await _visitorService.GetByIdAsync(item.VisitorId));
            }
            
            Logger.LogInformation($"Successfully advanced search for records. Count - {records.Count()}");
            if (User.IsInRole("admin"))
            {
                return View("Index", records);
            }
            return View("Index", records.Where(r => r.Visitor.Login == User.Identity.Name));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _recordService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
