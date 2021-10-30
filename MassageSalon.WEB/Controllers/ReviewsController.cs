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
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class ReviewsController : BaseController
    {
        private readonly IReviewService _reviewService;
        private readonly IMasseurService _masseurService;
        private readonly IVisitorService _visitorService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService,IMasseurService masseurService, IVisitorService visitorService, IHttpContextAccessor httpContextAccessor,  IMapper mapper)
        {
            _reviewService = reviewService;
            _masseurService = masseurService;
            _visitorService = visitorService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            Logger.LogInformation("Get request for reviews get all");
            var reviews = _reviewService.GetAll();
            return View(_mapper.Map<IEnumerable<ReviewModel>>(reviews));
        }
        [HttpGet]
        public IActionResult IndexForMasseur(int Id)
        {
            var reviews = _reviewService.GetAll();
            return View("Index", _mapper.Map<IEnumerable<ReviewModel>>(reviews.Where(r => r.MasseurId == Id)));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            IEnumerable<Masseur> masseurs = await _masseurService.GetAllAsync();
            ViewData["Masseurs"] = _mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs);
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ReviewModel review)
        {
            if(!ModelState.IsValid)
            {
                IEnumerable<Masseur> masseurs = await _masseurService.GetAllAsync();
                ViewData["Masseurs"] = _mapper.Map<IEnumerable<Masseur>, IEnumerable<MasseurModel>>(masseurs);

                return View(review);
            }
            Logger.LogInformation($"Get request for reviews add");
           
            review.VisitorId = _visitorService.Get(v => v.Login == User.Identity.Name).Id;

            await _reviewService.CreateAsync(_mapper.Map<ReviewModel, Review>(review));
            ViewBag.Message = "Success add review. Thanks for your attention";
            return RedirectToAction("Index", "Reviews");
        }
    }
}
