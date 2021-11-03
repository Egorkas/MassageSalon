using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Filters;
using MassageSalon.WEB.Models;
using MassageSalon.WEB.Models.PageModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<IActionResult> Index(int pageSize = 3, int page = 0)
        {
            Logger.LogInformation($"Get request for page {page}");
            var pageViewModel = new PageModel(await _offerService.GetCountAsync(), page, pageSize);

            var viewModel = new ViewPageModel<OfferModel>
            {
                PageModel = pageViewModel,
                Collection = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferModel>>(
                    _offerService.GetRange(page * pageSize, pageSize))
            };
            return View(viewModel);
        }

        //public IActionResult IndexForSearch()
        //{

        //}
        [AllowAnonymous]
        [CustomExceptionFilter]
        [HttpPost]
        public IActionResult Search(string search, int page = 0, int pageSize = 3)
        {
            Logger.LogInformation($"Get request for page {page}");
            var pageViewModel = new PageModel(_offerService.Search(search).Count(), page, pageSize);

            var viewModel = new ViewPageModel<OfferModel>
            {
                PageModel = pageViewModel,
                Collection = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferModel>>(
                    _offerService.Search(search))
            };
            return View("Index",viewModel);
        }
    }
}
