using ApiLivros.Context;
using ApiLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutoresController(AppDbContext context)
        {
            _context = context;
        }
    
        [HttpGet("livros")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutoresLivrosAsync()
        {
            var autores = await _context.Autores.Include(a => a.Livros).ToListAsync();

            return Ok(autores);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAllAutoresAsync()
        {
            var autores = await _context.Autores.ToListAsync();

            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutoresByIdAsync(int id)
        {
            var autores = await _context.Autores.FindAsync(id);

            if (autores == null)
            {
                return NotFound();
            }

            return Ok(autores);
        }

        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoresByIdAsync", new { id = autor.AutorId }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.AutorId)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.AutorId == id);
        }


    }
}
