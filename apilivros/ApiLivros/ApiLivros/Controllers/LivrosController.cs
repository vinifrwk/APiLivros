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
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivrosAsync()
        {
            var livros = await _context.Livros.ToListAsync();

            return Ok(livros);
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivroByIdAsync(int id)
        {
            var livros = await _context.Livros.FindAsync(id);

            if (livros == null)
            {
                return  NotFound();
            }

            return Ok(livros);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivroByIdAsync", new { id = livro.LivroId }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.LivroId == id);
        }
    }
}
