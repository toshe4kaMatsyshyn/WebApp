using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Controllers
{
    [Route("api/[controller]")]
    public class ProducedBrandsController : Controller
    {
        WebAppDatabaseContext db;
        public ProducedBrandsController(WebAppDatabaseContext context)
        {
            this.db = context;
            if (!db.ProducedBrands.Any())
            {
                db.ProducedBrands.Add(new ProducedBrands(new Brands("Cisco Inc."), 20, DateTime.Now));
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ProducedBrands> Get()
        {
            return db.ProducedBrands.ToList();
        }

        // GET api/producedbrands/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            ProducedBrands producedBrands = db.ProducedBrands.FirstOrDefault(x => x.Id == id);
            if (producedBrands == null)
                return NotFound();
            return new ObjectResult(producedBrands);
        }

        // POST api/producedbrands
        [HttpPost]
        public IActionResult Post(ProducedBrands producedBrands)
        {
            if (producedBrands == null)
            {
                return BadRequest();
            }

            db.ProducedBrands.Add(producedBrands);
            db.SaveChanges();
            return Ok(producedBrands);
        }

        // PUT api/producedbrands/
        [HttpPut]
        public IActionResult Put(ProducedBrands producedBrands)
        {
            if (producedBrands == null)
            {
                return BadRequest();
            }
            if (!db.ProducedBrands.Any(x => x.Id == producedBrands.Id))
            {
                return NotFound();
            }

            db.Update(producedBrands);
            db.SaveChanges();
            return Ok(producedBrands);
        }

        // DELETE api/producedbrands/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            ProducedBrands producedBrands = db.ProducedBrands.FirstOrDefault(x => x.Id == id);
            if (producedBrands == null)
            {
                return NotFound();
            }
            db.ProducedBrands.Remove(producedBrands);
            db.SaveChanges();
            return Ok(producedBrands);
        }
    }
}
