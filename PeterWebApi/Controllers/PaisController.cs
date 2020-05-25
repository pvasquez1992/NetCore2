using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeterWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace PeterWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PaisController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return _dbContext.Paises.ToList();

        }

        [HttpGet("{id}", Name = "paisCreado")]
        public IActionResult GetById(int id)
        {
            var pais = _dbContext.Paises.FirstOrDefault(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        [HttpPost]
        public IActionResult PostPais([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Paises.Add(pais);
                _dbContext.SaveChanges();
                return new CreatedAtRouteResult("paisCreado", new { id = pais.Id }, pais);
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public IActionResult EditPais([FromBody] Pais pais)
        {

            if (pais.Id > 0)
            {
                _dbContext.Entry(pais).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePais(int id)
        {
            var pais = _dbContext.Paises.FirstOrDefault(x => x.Id.Equals(id));

            if (pais == null)
            {
                return NotFound();
            }
            _dbContext.Paises.Remove(pais);
            _dbContext.SaveChanges();
            return Ok(pais);

        }

        //https://www.youtube.com/watch?v=GFRRFw4IIoI
    }
}
