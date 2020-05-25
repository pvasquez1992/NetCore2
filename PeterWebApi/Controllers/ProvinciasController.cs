using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeterWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeterWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais/{PaisId}/Provincia")]
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProvinciasController(ApplicationDbContext context) {
            _dbContext = context;
        }
        [HttpGet]
        public IEnumerable<Provincia> Get(int PaisId)
        {

            var result = _dbContext.Provincias.Where(x=> x.PaisId.Equals(PaisId)).ToList();
            return result;
        }

        [HttpGet("{id}", Name = "ProvinciaCreado")]
        public IActionResult GetById(int id)
        {
            var Provincia = _dbContext.Provincias.FirstOrDefault(x => x.Id == id);

            if (Provincia == null)
            {
                return NotFound();
            }

            return Ok(Provincia);
        }

        [HttpPost]
        public IActionResult PostProvincia([FromBody] Provincia Provincia)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Provincias.Add(Provincia);
                _dbContext.SaveChanges();
                return new CreatedAtRouteResult("ProvinciaCreado", new { id = Provincia.Id }, Provincia);
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public IActionResult EditProvincia([FromBody] Provincia Provincia)
        {

            if (Provincia.Id > 0)
            {
                _dbContext.Entry(Provincia).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProvincia(int id)
        {
            var Provincia = _dbContext.Provincias.FirstOrDefault(x => x.Id.Equals(id));

            if (Provincia == null)
            {
                return NotFound();
            }
            _dbContext.Provincias.Remove(Provincia);
            _dbContext.SaveChanges();
            return Ok(Provincia);

        }

    }
}