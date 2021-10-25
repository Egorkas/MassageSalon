using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Filters;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

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
        public async Task<IActionResult> Index(int page = 1)
        {
            var qry = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferModel>>(await _offerService.GetAllAsync());
            var offers = PagingList.Create(qry, 2, page);
            return View(offers);
        }
        [AllowAnonymous]
        [CustomExceptionFilter]
        public IActionResult Search(string search, int page = 1)
        {
            var qry = _mapper.Map<IEnumerable<OfferModel>>(_offerService.Search(search));
            var offers = PagingList.Create(qry, 2, page);
            return View("Index", offers );
        }
    }
}
