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
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorService _service;

        public VisitorsController(IVisitorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Visitor>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Visitor> Get(int id)
        {
            var visitor = _service.GetById(id);

            if (visitor == null)
                NotFound();
            return Ok(visitor);
        }

        [HttpPost]
        public ActionResult<Visitor> Add(Visitor visitor)
        {
            if (visitor == null)
                BadRequest();
            _service.Create(visitor);
            return Ok(visitor);
        }

        [HttpPut]
        public ActionResult<Visitor> Update(Visitor visitor)
        {
            if (visitor == null)
            {
                BadRequest();
            }
            if (_service.GetById(visitor.Id) == null)
            {
                NotFound();
            }

            _service.Update(visitor);
            return Ok(visitor);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var visitor = _service.GetById(id);
            if (visitor == null)
            {
                NotFound();
            }
            _service.Delete(id);
        }
    }
}
