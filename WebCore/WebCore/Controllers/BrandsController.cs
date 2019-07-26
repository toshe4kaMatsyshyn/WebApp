using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Controllers
{
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
           WebAppDatabaseContext db;
            public BrandsController(WebAppDatabaseContext context)
            {
                this.db = context;
                if (!db.Brands.Any())
                {
                    db.Brands.Add(new Brands("Cisco Inc"));
                    db.Brands.Add(new Brands("Google Inc"));
                    db.SaveChanges();
                }
            }

            [HttpGet]
            public IEnumerable<Brands> Get()
            {
                return db.Brands.ToList();
            }

            // GET api/users/5
            [HttpGet("{id}")]
            public IActionResult Get(string id)
            {
                Brands brands = db.Brands.FirstOrDefault(x => x.Id == id);
                if (brands == null)
                    return NotFound();
                return new ObjectResult(brands);
            }

            // POST api/users
            [HttpPost]
            public IActionResult Post([FromBody]Brands brands)
            {
                if (brands == null)
                {
                    return BadRequest();
                }

                db.Brands.Add(brands);
                db.SaveChanges();
                return Ok(brands);
            }

            // PUT api/users/
            [HttpPut]
            public IActionResult Put([FromBody]Brands brands)
            {
                if (brands == null)
                {
                    return BadRequest();
                }
                if (!db.Brands.Any(x => x.Id == brands.Id))
                {
                    return NotFound();
                }

                db.Update(brands);
                db.SaveChanges();
                return Ok(brands);
            }

            // DELETE api/users/5
            [HttpDelete("{id}")]
            public IActionResult Delete(string id)
            {
                Brands brands = db.Brands.FirstOrDefault(x => x.Id == id);
                if (brands == null)
                {
                    return NotFound();
                }
                db.Brands.Remove(brands);
                db.SaveChanges();
                return Ok(brands);
            }
        
    }
}
