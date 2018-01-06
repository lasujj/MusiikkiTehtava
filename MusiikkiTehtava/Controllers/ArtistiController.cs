using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusiikkiTehtava.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MusiikkiTehtava.Controllers
{
    [Route("api/musiikki/[controller]")]
    public class ArtistiController : Controller
    {
        private readonly MusiikkiContext _context;

        public ArtistiController(MusiikkiContext context)
        {
            _context = context;

         
        }

        [HttpGet]
        public IEnumerable<Artisti> GetAll()
        {
            return _context.Artistit.Include(k => k.Kappaleet).ToList();
        }

        [HttpGet("{id}", Name = "GetArtisti")]
        public IActionResult GetById(long id)
        {
            var item = _context.Artistit.FirstOrDefault(t => t.ArtistiId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Artisti item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Artistit.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArtisti", new { id = item.ArtistiId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Artisti item)
        {
            if (item == null || item.ArtistiId != id)
            {
                return BadRequest();
            }

            var todo = _context.Artistit.FirstOrDefault(t => t.ArtistiId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nimi = item.Nimi;
            todo.Genre = item.Genre;
            todo.ArtistiId = item.ArtistiId;

            _context.Artistit.Update(todo);
            _context.SaveChanges();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Artistit.FirstOrDefault(t => t.ArtistiId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Artistit.Remove(todo);
            _context.SaveChanges();
            return new OkResult();
        }
    }


}

