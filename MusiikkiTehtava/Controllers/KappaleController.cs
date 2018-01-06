using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusiikkiTehtava.Models;
using System.Linq;
using MusiikkiTehtava.Filters;

namespace MusiikkiTehtava.Controllers
{
    [Route("api/musiikki/[controller]")]
    public class KappaleController : Controller
    {
        private readonly MusiikkiContext _context;

        public KappaleController(MusiikkiContext context)
        {
            _context = context;
  
        }

        [HttpGet]
        public IEnumerable<Kappale> GetAll([FromQuery] Suodatin hakusuodatin)
        {
            
            return _context.Kappaleet.Where(c => (c.Nimi == hakusuodatin.KappaleenNimi || hakusuodatin.KappaleenNimi == null ) &&
            (c.Artisti.Nimi == hakusuodatin.ArtistinNimi || hakusuodatin.ArtistinNimi == null ) &&
            (c.Albumi.Nimi == hakusuodatin.AlbuminNimi || hakusuodatin.AlbuminNimi == null) &&
            (c.Artisti.Genre == hakusuodatin.Genre || hakusuodatin.Genre == null)).ToList();
        }

        [HttpGet("{id}", Name = "GetKappale")]
        public IActionResult GetById(long id)
        {
            var item = _context.Kappaleet.FirstOrDefault(t => t.KappaleId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        

        [HttpPost]
        public IActionResult Create([FromBody] Kappale item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Kappaleet.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetKappale", new { id = item.KappaleId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Kappale item)
        {
            if (item == null || item.KappaleId != id)
            {
                return BadRequest();
            }

            var todo = _context.Kappaleet.FirstOrDefault(t => t.KappaleId == id);
            if (todo == null)
            {
                return NotFound();
            }
            if (item.ArtistiId != null)
            {
                todo.ArtistiId = item.ArtistiId;
            }
            if (item.Nimi != null)
            {
                todo.Nimi = item.Nimi;
            }           
           
            if (item.AlbumiId != null)
            {
                todo.AlbumiId = item.AlbumiId;
            }
            

            _context.Kappaleet.Update(todo);
            _context.SaveChanges();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Kappaleet.FirstOrDefault(t => t.KappaleId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Kappaleet.Remove(todo);
            _context.SaveChanges();
            return new OkResult();
        }
    }


}

