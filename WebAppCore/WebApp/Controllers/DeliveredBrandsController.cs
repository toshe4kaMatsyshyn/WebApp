using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class DeliveredBrandsController : Controller
    {
        WebAppDatabaseContext db;
        public DeliveredBrandsController(WebAppDatabaseContext context)
        {
            
            this.db = context;
            if (!db.DeliveredBrands.Any())
            {
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<DeliveredBrands> Get()
        {
            return db.DeliveredBrands.ToList();
        }

        // GET api/deliveredbrands/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DeliveredBrands deliveredBrands = db.DeliveredBrands.FirstOrDefault(x => x.Id == id);
            if (deliveredBrands == null)
                return NotFound();
            return new ObjectResult(deliveredBrands);
        }

        // POST api/deliveredbrands
        [HttpPost]
        public IActionResult Post([FromBody]DeliveredBrands deliveredBrands)
        {
            if (deliveredBrands == null)
            {
                return BadRequest();
            }
            deliveredBrands.Id = Settings.GenerateId();

            db.DeliveredBrands.Add(deliveredBrands);
            db.SaveChanges();
            return Ok(deliveredBrands);
        }

        // PUT api/deliveredbrands/
        [HttpPut]
        public IActionResult Put([FromBody]DeliveredBrands deliveredBrands)
        {
            if (deliveredBrands == null)
            {
                return BadRequest();
            }
            if (!db.DeliveredBrands.Any(x => x.Id == deliveredBrands.Id))
            {
                return NotFound();
            }

            db.Update(deliveredBrands);
            db.SaveChanges();
            return Ok(deliveredBrands);
        }

        // DELETE api/deliveredbrands/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            DeliveredBrands deliveredBrands = db.DeliveredBrands.FirstOrDefault(x => x.Id == id);
            if (deliveredBrands == null)
            {
                return NotFound();
            }
            db.DeliveredBrands.Remove(deliveredBrands);
            db.SaveChanges();
            return Ok(deliveredBrands);
        }
    }
}
