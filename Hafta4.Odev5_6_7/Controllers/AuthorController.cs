using AutoMapper;
using FluentValidation.Results;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev5_6_7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hafta4.Odev5_6_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(AuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAuthorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetGenresAsync()
        {
            var result = await _authorService.GetAuthorsAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [ProducesResponseType(typeof(GetAuthorViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAuthorDetailByIdAsync(int id)
        {
            var result = await _authorService.GetAuthorByIdAsync(id);

            return Ok(result);
        }

        // POST: api/author
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddGenreAsync([FromBody] CreateAuthorDto author)
        {

            ValidationResult result = new CreateAuthorValidator().Validate(author);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            await _authorService.AddAuthorAsync(author);

            return Ok();
        }

        // PUT: api/authors/5
        [HttpPut]
        [Route("authors/{id:int:min(1)}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateAuthorDto updateAuthor)
        {
            ValidationResult result = new UpdateAuthorValidator().Validate(updateAuthor);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _authorService.UpdateAuthor(updateAuthor, id);

            return Ok();
        }

        // DELETE: api/authors/5
        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            await _authorService.DeleteAuthorAsync(id);

            return NoContent();
        }
    }
}