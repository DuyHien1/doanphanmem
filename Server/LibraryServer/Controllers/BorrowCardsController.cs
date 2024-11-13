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
    public class BorrowCardsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BorrowCardsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/BorrowCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowCard>>> GetBorrowCards()
        {
            return await _context.BorrowCards.ToListAsync();
        }

        // GET: api/BorrowCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowCard>> GetBorrowCard(int id)
        {
            var borrowCard = await _context.BorrowCards.FindAsync(id);

            if (borrowCard == null)
            {
                return NotFound();
            }

            return borrowCard;
        }

        // PUT: api/BorrowCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowCard(int id, BorrowCard borrowCard)
        {
            if (id != borrowCard.brcardId)
            {
                return BadRequest();
            }

            _context.Entry(borrowCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowCardExists(id))
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

        // POST: api/BorrowCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BorrowCard>> PostBorrowCard(BorrowCard borrowCard)
        {
            _context.BorrowCards.Add(borrowCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowCard", new { id = borrowCard.brcardId }, borrowCard);
        }

        // DELETE: api/BorrowCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowCard(int id)
        {
            var borrowCard = await _context.BorrowCards.FindAsync(id);
            if (borrowCard == null)
            {
                return NotFound();
            }

            _context.BorrowCards.Remove(borrowCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowCardExists(int id)
        {
            return _context.BorrowCards.Any(e => e.brcardId == id);
        }
    }
}
