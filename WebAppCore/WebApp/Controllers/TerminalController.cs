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
    public class TerminalController : Controller
    {
        WebAppDatabaseContext db;
        public TerminalController(WebAppDatabaseContext context)
        {
            
            this.db = context;
            if (!db.Terminal.Any())
            {
                db.Terminal.Add(new Terminal ( "Boryspol Term", 20));
                db.Terminal.Add(new Terminal("Bgolybov Term", 2));
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Terminal> Get()
        {
            return db.Terminal.ToList();
        }

        // GET api/terminal/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Terminal terminal = db.Terminal.FirstOrDefault(x => x.Id == id);
            if (terminal == null)
                return NotFound();
            return new ObjectResult(terminal);
        }

        // POST api/terminal
        [HttpPost]
        public IActionResult Post([FromBody]Terminal terminal)
        {
            terminal.Id = Settings.GenerateId();
            if (terminal == null)
            {
                return BadRequest();
            }

            db.Terminal.Add(terminal);
            db.SaveChanges();
            return Ok(terminal);
        }

        // PUT api/terminal/
        [HttpPut]
        public IActionResult Put([FromBody]Terminal terminal)
        {
            if (terminal == null)
            {
                return BadRequest();
            }
            if (!db.Terminal.Any(x => x.Id == terminal.Id))
            {
                return NotFound();
            }

            db.Update(terminal);
            db.SaveChanges();
            return Ok(terminal);
        }

        // DELETE api/terminal/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Terminal terminal = db.Terminal.FirstOrDefault(x => x.Id == id);
            if (terminal == null)
            {
                return NotFound();
            }
            db.Terminal.Remove(terminal);
            db.SaveChanges();
            return Ok(terminal);
        }
    }
}
