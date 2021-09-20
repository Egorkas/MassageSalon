using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class MasseursController : BaseController
    {
        private readonly IMasseurService _masseurService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public MasseursController(IMasseurService masseurService, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _masseurService = masseurService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var masseurs = _masseurService.GetAll();
            return View(_mapper.Map<IEnumerable<MasseurModel>>(masseurs));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var visitor = _masseurService.GetById(id);

            if (visitor == null)
                return NotFound();
            return View(_mapper.Map<MasseurModel>(visitor));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(MasseurModel masseur, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    masseur.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                _masseurService.Create(_mapper.Map<Masseur>(masseur));
                return RedirectToAction("Index");
            }

            return View(masseur);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            _masseurService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
