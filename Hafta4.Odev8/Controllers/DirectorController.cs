using AutoMapper;
using FluentValidation;
using Hafta4.Odev8.Application.DirectorOperations.Commands.CreateDirector;
using Hafta4.Odev8.Application.DirectorOperations.Commands.DeleteDirector;
using Hafta4.Odev8.Application.DirectorOperations.Commands.UpdateDirector;
using Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectorDetails;
using Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectors;
using Hafta4.Odev8.DbOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Hafta4.Odev8.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static Hafta4.Odev8.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectorDetails.GetDirectorDetailQuery;

namespace Hafta4.Odev8.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet] // Tüm yönetmenleri getir
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")] // ID'ye göre yönetmen getir
        public IActionResult GetById(int id)
        {
            DirectorDetailViewModel result;
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = id;
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost] // Yönetmen ekleme
        public IActionResult AddDirector([FromBody] CreateDirectorViewModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete] // Yönetmen silme
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")] // Yönetmen güncelle
        public IActionResult UpdateDirector([FromBody] UpdateDirectorViewModel updatedDirector, int id)
        {

            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);
            command.DirectorId = id;
            command.Model = updatedDirector;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
