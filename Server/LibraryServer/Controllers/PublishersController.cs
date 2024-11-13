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
    public class PublishersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PublishersController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/Publishers/List
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetListPublishers()
        {
            // Logic to return a specific list of publishers, if different from GetPublishers
            return await _context.Publishers.ToListAsync();
        }



        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(string id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(string id, Publisher publisher)
        {
            if (id != publisher.publisherName)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PublisherExists(publisher.publisherName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPublisher", new { id = publisher.publisherName }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(string id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublisherExists(string id)
        {
            return _context.Publishers.Any(e => e.publisherName == id);
        }
    }
}
