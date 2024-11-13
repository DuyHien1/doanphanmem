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
    public class ReaderCardsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ReaderCardsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/ReaderCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderCard>>> GetReaderCarts()
        {
            return await _context.ReaderCarts.ToListAsync();
        }

        // GET: api/ReaderCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderCard>> GetReaderCard(int id)
        {
            var readerCard = await _context.ReaderCarts.FindAsync(id);

            if (readerCard == null)
            {
                return NotFound();
            }

            return readerCard;
        }

        // PUT: api/ReaderCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaderCard(int id, ReaderCard readerCard)
        {
            if (id != readerCard.CardId)
            {
                return BadRequest();
            }

            _context.Entry(readerCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderCardExists(id))
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

        // POST: api/ReaderCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReaderCard>> PostReaderCard(ReaderCard readerCard)
        {
            _context.ReaderCarts.Add(readerCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReaderCard", new { id = readerCard.CardId }, readerCard);
        }

        // DELETE: api/ReaderCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderCard(int id)
        {
            var readerCard = await _context.ReaderCarts.FindAsync(id);
            if (readerCard == null)
            {
                return NotFound();
            }

            _context.ReaderCarts.Remove(readerCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReaderCardExists(int id)
        {
            return _context.ReaderCarts.Any(e => e.CardId == id);
        }
    }
}
