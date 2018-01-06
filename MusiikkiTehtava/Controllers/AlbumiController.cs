using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusiikkiTehtava.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MusiikkiTehtava.Controllers
{
    [Route("api/musiikki/[controller]")]
    public class AlbumiController : Controller
    {
        private readonly MusiikkiContext _context;

        public AlbumiController(MusiikkiContext context)
        {
            _context = context;
            
            
         
        }

        [HttpGet]
        public IEnumerable<Albumi> GetAll()
        {
            var albumit =  _context.Albumit.Include(k => k.Kappalelistaus).ToList();
            return albumit;
            
        }

        [HttpGet("{id}", Name = "GetAlbumi")]
        public IActionResult GetById(long id)
        {
            var item = _context.Albumit.FirstOrDefault(t => t.AlbumiId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Albumi item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Albumit.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAlbumi", new { id = item.AlbumiId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Albumi item)
        {
            if (item == null || item.AlbumiId != id)
            {
                return BadRequest();
            }

            var todo = _context.Albumit.FirstOrDefault(t => t.AlbumiId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Nimi = item.Nimi;
            todo.Julkaisuvuosi = item.Julkaisuvuosi;
            todo.Kappalelistaus = item.Kappalelistaus;
            todo.AlbumiId = item.AlbumiId;


            _context.Albumit.Update(todo);
            _context.SaveChanges();
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Albumit.FirstOrDefault(t => t.AlbumiId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Albumit.Remove(todo);
            _context.SaveChanges();
            return new OkResult();
        }
    }


}

