using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MassageSalon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasseursController : ControllerBase
    {
        private readonly IMasseurService _service;

        public MasseursController(IMasseurService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Masseur>> GetAll()
        {
            return Ok(_service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Masseur> Get(int id)
        {
            var Masseur = _service.GetByIdAsync(id);

            if (Masseur == null)
                NotFound();
            return Ok(Masseur);
        }

        [HttpPost]
        public ActionResult<Masseur> Add(Masseur Masseur)
        {
            if (Masseur == null)
                BadRequest();
            _service.CreateAsync(Masseur);
            return Ok(Masseur);
        }

        [HttpPut]
        public ActionResult<Masseur> Update(Masseur Masseur)
        {
            if (Masseur == null)
            {
                BadRequest();
            }
            if (_service.GetByIdAsync(Masseur.Id) == null)
            {
                NotFound();
            }

            _service.UpdateAsync(Masseur);
            return Ok(Masseur);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var Masseur = _service.GetByIdAsync(id);
            if (Masseur == null)
            {
                NotFound();
            }
            _service.DeleteAsync(id);
        }
    }
}
