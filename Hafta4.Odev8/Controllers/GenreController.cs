using AutoMapper;
using FluentValidation;
using Hafta4.Odev8.Application.GenreOperations.Commands.CreateGenre;
using Hafta4.Odev8.Application.GenreOperations.Commands.DeleteGenre;
using Hafta4.Odev8.Application.GenreOperations.Commands.UpdateGenre;
using Hafta4.Odev8.Application.GenreOperations.Queries.GetGenreDetails;
using Hafta4.Odev8.Application.GenreOperations.Queries.GetGenres;
using Hafta4.Odev8.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static Hafta4.Odev8.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static Hafta4.Odev8.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static Hafta4.Odev8.Application.GenreOperations.Queries.GetGenreDetails.GetGenreDetailQuery;

namespace Hafta4.Odev8.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] // Tüm janraları getir
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")] // ID'ye göre janra getir
        public IActionResult GetById(int id)
        {
            GenreDetailViewModel result;
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost] // Janra ekleme
        public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Hande();
            return Ok();

        }

        [HttpDelete] // Janra silme
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")] // Janra güncelleme
        public IActionResult UpdateGenre([FromBody] UpdateGenreViewModel updatedGenre, int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            command.GenreId = id;
            command.Model = updatedGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
