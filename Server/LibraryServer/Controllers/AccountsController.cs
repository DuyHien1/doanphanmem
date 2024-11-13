using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AccountsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid client request");
            }

            var account = _context.Accounts.SingleOrDefault(a => a.UserName == loginRequest.UserName && a.Password == loginRequest.Password);

            if (account == null)
            {
                return Unauthorized();
            }

            return Ok(new { account.UserName, account.Role, account.UserId });
        }
        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.UserId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.UserId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.UserId == id);
        }
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LoginRequest loginRequest)
        {
            var userAvailable = _context.Accounts.Where(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password).FirstOrDefault();
            if (userAvailable == null)
            {
                return Ok("Failure");
            }
            return Ok(new { userAvailable.UserName, userAvailable.Role, userAvailable.UserId });
        }
        // GET: api/Accounts/GetUserName/{id}
        [HttpGet("GetUserName/{id}")]
        public async Task<ActionResult<string>> GetUserName(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account.UserName);
        }
    }
}
