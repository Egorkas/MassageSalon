using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            Logger.LogInformation("Get request for masseursGet All");
            var masseurs = _masseurService.GetWithInclude();
            return View(_mapper.Map<IEnumerable<MasseurModel>>(masseurs));
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Add()
        {
            MasseurModel masseur = new MasseurModel() {TitleImagePath = "user_profile.jpg" };
            return View("Edit", masseur);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(MasseurModel masseur)
        {
            return View(masseur);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(MasseurModel masseur, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    masseur.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images/ProfilesPhoto/", titleImageFile.FileName), FileMode.Create))
                    {
                        await titleImageFile.CopyToAsync(stream);
                    }
                }
                else masseur.TitleImagePath = "user_profile.jpg";
                if (masseur.Id == 0)
                {
                    await _masseurService.CreateAsync(_mapper.Map<Masseur>(masseur));
                    Logger.LogInformation("Create new model of masseur");
                }else
                await _masseurService.UpdateAsync(_mapper.Map<Masseur>(masseur));
                return RedirectToAction("Index");
            }
            Logger.LogInformation("Model for edit masseurs isn't valid");
            return View(masseur);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {

            await _masseurService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
