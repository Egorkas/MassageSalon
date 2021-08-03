using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
    public class MasseursController : Controller
    {
        private readonly IMasseurService _masseurService;
        private readonly IMapper _mapper;

        public MasseursController(IMasseurService masseurService, IMapper mapper)
        {
            _masseurService = masseurService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var masseurs = _masseurService.GetAll();
            return View(_mapper.Map<IEnumerable<MasseurModel>>(masseurs));
        }
    }
}
