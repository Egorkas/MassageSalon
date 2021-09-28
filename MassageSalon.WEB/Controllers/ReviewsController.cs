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
        public IActionResult Edit()
        {
            IEnumerable<Masseur> masseurs = _masseurService.GetAll();
            return View(_mapper.Map<IEnumerable<Masseur>,IEnumerable<MasseurModel>>(masseurs));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string? reviewDesc, int? masseurId)
        {
            if (masseurId == null || reviewDesc == null)
            {
                ModelState.AddModelError("", "Review text an must not be null");
                return RedirectToAction("Index", "Reviews");
            }

            Logger.LogInformation($"Get request for reviews add");
            var review = new ReviewModel()
            {
                MasseurId = _mapper.Map<Masseur, MasseurModel>(_masseurService.GetById((int)masseurId)).Id,
                UserReview = reviewDesc,
                VisitorId = _visitorService.Get(u => u.Login == User.Identity.Name).Id
            };

            _reviewService.Create(_mapper.Map<ReviewModel, Review>(review));
            ViewBag.Message = "Success add review. Thanks for your attention";
            return RedirectToAction("Index", "Reviews");
        }
    }
}
