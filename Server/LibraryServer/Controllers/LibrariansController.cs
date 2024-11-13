using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariansController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LibrariansController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Librarians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Librarian>>> GetLibrarians()
        {
            return await _context.Librarians.ToListAsync();
        }

        // GET: api/Librarians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Librarian>> GetLibrarian(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);

            if (librarian == null)
            {
                return NotFound();
            }

            return librarian;
        }

        // PUT: api/Librarians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrarian(int id, Librarian librarian)
        {
            if (id != librarian.LibId)
            {
                return BadRequest();
            }

            _context.Entry(librarian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarianExists(id))
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

        // POST: api/Librarians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Librarian>> PostLibrarian(Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrarian", new { id = librarian.LibId }, librarian);
        }

        // DELETE: api/Librarians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrarian(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }

            _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibrarianExists(int id)
        {
            return _context.Librarians.Any(e => e.LibId == id);
        }
    }
}
