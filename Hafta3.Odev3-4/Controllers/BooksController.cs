using FluentValidation.Results;
using Hafta3.Odev3_4.ActionFilters;
using Hafta3.Odev3_4.Dtos.BookOperations;
using Hafta3.Odev3_4.Entities;
using Hafta3.Odev3_4.Services;
using Hafta3.Odev3_4.Validators;
using Hafta3.Odev3_4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hafta3.Odev3_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireUserLogin] // Custom login verifier attribute
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IConfiguration configuration;

        public BooksController(BookService bookService, IConfiguration configuration)
        {
            _bookService = bookService;
            this.configuration = configuration;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(typeof(GetBooksViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetBooksAsync()
        {
            var result = await _bookService.GetBooksAsync();

            return Ok(result);
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GetBookViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetBookByIdAsync(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);

            return Ok(result);
        }

        // GET: api/Books/search?title=Dune
        [HttpGet]
        [Route("search")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GetBooksViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> SearchBooksByTitleAsync([FromQuery] string title)
        {
            var result = await _bookService.SearchBooksByTitleAsync(title);

            return Ok(result);
        }

        // GET: api/Books/list?filter=publishDate&orderby=asc
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(GetBooksViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetFilteredBooksWithOrderAsync([FromQuery] string filter, [FromQuery] string orderby = "asc")
        {
            var result = await _bookService.GetFilteredBooksWithOrderAsync(filter, orderby);

            return Ok(result);
        }

        // PUT: api/books/5
        [HttpPut]
        [Route("books/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookDto book)
        {
            ValidationResult result = new UpdateBookValidator().Validate(book);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _bookService.UpdateBook(book);

            return Ok();
        }

        // POST: api/Books
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Book>> CreateBookAsync([FromBody] CreateBookDto book)
        {
            ValidationResult result = new CreateBookValidator().Validate(book);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var bookId = await _bookService.AddBookAsync(book);

            var uri = configuration.GetValue<string>("Uri");

            return Created(uri + $"/Books/{bookId}", book);
        }

        // DELETE: api/Books/5
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            await _bookService.DeleteBook(id);

            return NoContent();
        }
    }
}
