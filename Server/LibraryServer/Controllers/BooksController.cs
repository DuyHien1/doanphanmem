using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Web;
namespace LibraryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly string _uploadPath = @"D:\nam4_hk3\CNPM ly thuyết\code\LibraryServer\LibraryServer\Images";
        private readonly IWebHostEnvironment _enviroment;

        public BooksController(MyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviroment = _enviroment;

        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

        // New endpoint to associate the uploaded image with a book
        [HttpPut("{bookId}/associate-image")]
        public async Task<IActionResult> AssociateImageWithBook(int bookId, [FromBody] string filePath)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            book.ImagePath = filePath;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Image associated with book successfully." });
        }
        //mượn sách
        // PUT: api/books/borrow/{id}
        [HttpPut("borrow/{id}")]
        public async Task<IActionResult> BorrowBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            // Update status to "Considered"
            book.status = "Considered";
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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
        // PUT: api/books/approve/5
        [HttpPut("approve/{id}")]
        public IActionResult ApproveBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            // Update book status to 'Approved'
            book.status = "Approved";
            _context.SaveChanges();

            return NoContent();
        }

        // PUT: api/books/return/5
        [HttpPut("return/{id}")]
        public IActionResult ReturnBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            // Update book status to 'Available'
            book.status = "Available";
            _context.SaveChanges();

            return NoContent();
        }
        // GET: api/books/status/Considered
        [HttpGet("status/{status}")]
        public ActionResult<IEnumerable<Book>> GetBooksByStatus(string status)
        {
            var books = _context.Books.Where(b => b.status == status).ToList();
            return books;
        }
        //



        //
        [NonAction]
        private string GetFilePath(string bookId)
        {
            return Path.Combine(_enviroment.WebRootPath, "Uploads", "Books", bookId);
        }

        [NonAction]
        private string GetImageByBook(string bookId)
        {
            string imageUrl = string.Empty;
            string hostUrl = "http://localhost:4200/";
            string filepath = GetFilePath(bookId);
            string imagepath = Path.Combine(filepath, "image.png");

            if (!System.IO.File.Exists(imagepath))
            {
                imageUrl = Path.Combine(hostUrl, "uploads", "common", bookId, "noimage.png");
            }
            else
            {
                imageUrl = Path.Combine(hostUrl, "uploads", "books", bookId, "image.png");
            }
            return imageUrl;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage()
        {
            bool result = false;
            try
            {
                var uploadedFiles = Request.Form.Files;
                foreach (IFormFile source in uploadedFiles)
                {
                    string fileName = source.FileName;
                    string filePath = GetFilePath(fileName);

                    if (!System.IO.Directory.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(filePath);
                    }

                    string imagePath = Path.Combine(filePath, "image.png");

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (FileStream stream = System.IO.File.Create(imagePath))
                    {
                        await source.CopyToAsync(stream);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception here
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

            return Ok(result);
        }



    }
}

