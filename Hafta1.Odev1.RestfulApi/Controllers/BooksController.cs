using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hafta1.Odev1.RestfulApi.DbOperations;
using Hafta1.Odev1.RestfulApi.Entities;
using System.Net;
using FluentValidation.Results;
using Hafta1.Odev1.RestfulApi.Validators;
using System.Linq.Expressions;
using Hafta1.Odev1.RestfulApi.Extensions;

namespace Hafta1.Odev1.RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IConfiguration configuration;

        public BooksController(BookStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetBooksAsync()
        {
            var result = await _context.Books.ToListAsync();

            return Ok(result);
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetBookAsync(int id)
        {
            if (id < 1)
                return BadRequest("Book id must be greater than 0!");

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound($"Book with id: {id} not found.");
            }

            return Ok(book);
        }

        // GET: api/Books/search?title=Dune
        [HttpGet]
        [Route("search")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> SearchBooksByTitleAsync([FromQuery] string title)
        {
            var books = await _context.Books.Where(x => x.Title.Contains(title)).ToListAsync();

            if (books == null)
            {
                return NotFound($"There is no Book Title that contains: {title}");
            }

            return Ok(books);
        }

        // GET: api/Books/list?filter=publishDate&orderby=asc
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(List<Book>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetFilteredBooksWithOrderAsync([FromQuery] string filter, [FromQuery] string orderby = "asc")
        {
            try
            {
                var books = new List<Book>();
                if (orderby == "asc")
                    books = await _context.Books.OrderBy<Book>(filter).ToListAsync();
                else
                    books = await _context.Books.OrderByDescending<Book>(filter).ToListAsync();
                return Ok(books);
            }
            catch
            {
                return BadRequest("Wrong parameter entered for filtering Books!");
            }
        }

        // PUT: api/books/5
        [HttpPut]
        [Route("books/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] Book book)
        {
            ValidationResult result = new BookValidator().Validate(book);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            ValidationResult result = new BookValidator().Validate(book);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var uri = configuration.GetValue<string>("Uri");

            return Created(uri + $"/Books/{book.Id}", book);
        }

        // DELETE: api/Books/5
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound($"Book to delete with id: {id} not found!");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
