using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;


namespace Hafta4.Odev7_UnitTests_.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGenreCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_Exception_ShouldBeReturn()
        {
            // Arrange (preparation)

            GenreService service = new GenreService(_context, _mapper);
            UpdateGenreDto genreToUpdate = new UpdateGenreDto() { Name = "Personal Growth" };

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(() => service.UpdateGenre(genreToUpdate, 3))
                .Should().Throw<Exception>();
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
        {
            // Arrange (preparation)
            GenreService service = new GenreService(_context, _mapper);
            UpdateGenreDto genreToUpdate = new UpdateGenreDto() { Name = "Fantasy" };

            // Act
            FluentActions.Invoking(() => service.UpdateGenre(genreToUpdate, 2)).Invoke();

            //// Assert
            var genre = _context.Genres.SingleOrDefault(x => x.Name == genreToUpdate.Name);

            genre.Should().NotBeNull();
            genre.Name.Should().Be(genreToUpdate.Name);
        }
    }
}
