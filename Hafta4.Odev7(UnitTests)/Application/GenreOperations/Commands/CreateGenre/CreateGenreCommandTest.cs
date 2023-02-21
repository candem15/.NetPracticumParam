using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_Exception_ShouldBeReturn()
        {
            // Arrange (preparation)

            GenreService service = new GenreService(_context, _mapper);
            CreateGenreDto genreToCreate = new CreateGenreDto() { Name = "Personal Growth" };

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.AddGenreAsync(genreToCreate))
                .Should().ThrowAsync<Exception>().Result.WithMessage("Genre to create is already exists!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            // Arrange (preparation)
            GenreService service = new GenreService(_context, _mapper);
            CreateGenreDto genreToCreate = new CreateGenreDto() { Name = "Fantasy" };

            // Act
            FluentActions.Invoking(() => service.AddGenreAsync(genreToCreate)).Invoke();

            //// Assert
            var genre = _context.Genres.SingleOrDefault(x => x.Name == genreToCreate.Name);

            genre.Should().NotBeNull();
            genre.Name.Should().Be(genreToCreate.Name);
        }
    }
}
