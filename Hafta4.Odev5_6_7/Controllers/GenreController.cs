using AutoMapper;
using FluentValidation.Results;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev5_6_7.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hafta4.Odev5_6_7.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(GenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetGenreViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetGenresAsync()
        {
            var result = await _genreService.GetGenresAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(GetGenreViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetGenreDetailByIdAsync(int id)
        {
            var result = await _genreService.GetGenreByIdAsync(id);

            return Ok(result);
        }

        // POST: api/genre
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddGenreAsync([FromBody] CreateGenreDto genre)
        {

            ValidationResult result = new CreateGenreValidator().Validate(genre);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            await _genreService.AddGenreAsync(genre);

            return Ok();
        }

        // PUT: api/genres/5
        [HttpPut]
        [Route("genres/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreDto updateGenre)
        {
            ValidationResult result = new UpdateGenreValidator().Validate(updateGenre);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _genreService.UpdateGenre(updateGenre);

            return Ok();
        }

        // DELETE: api/Genres/5
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            await _genreService.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}
