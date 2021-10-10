using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class OfferController : BaseController
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var offers = _offerService.GetAll();
            return View(_mapper.Map<IEnumerable<Offer>,IEnumerable<OfferModel>>(offers));
        }
        [AllowAnonymous]
        public IActionResult Search(string search)
        {
            var offers = _offerService.Search(search);
            return View("Index", _mapper.Map<IEnumerable<OfferModel>>(offers));
        }
    }
}
