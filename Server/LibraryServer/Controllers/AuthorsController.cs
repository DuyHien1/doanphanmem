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
    public class AuthorsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AuthorsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/name
        [HttpGet("{name}")]
        public async Task<ActionResult<Author>> GetAuthor(string name)
        {
            var author = await _context.Authors.FindAsync(name);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/name
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{name}")]
        public async Task<IActionResult> PutAuthor(string name, Author author)
        {
            if (name != author.AuthorName)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(name))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorExists(author.AuthorName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthor", new { name = author.AuthorName }, author);
        }

        // DELETE: api/Authors/name
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAuthor(string name)
        {
            var author = await _context.Authors.FindAsync(name);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(string name)
        {
            return _context.Authors.Any(e => e.AuthorName == name);
        }

        // GET: api/Authors/List
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorList()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
