using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [Theory]
        [InlineData(30)]
        [InlineData(0)]
        [InlineData(-2)]
        public void WhenGivenAuthorIdIsNotExist_AuthorNotExistsException_ShouldBeReturnErrors(int id)
        {
            // Arrange
            AuthorService service = new AuthorService(_context, _mapper);

            // Act and Assert
            FluentActions.Invoking(() => service.UpdateAuthor(new UpdateAuthorDto() { Name = "Eray", Surname = "Test", DateOfBirth = DateTime.Now.AddYears(-5) }, id)).Should().Throw<AuthorNotExistsException>();
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeUpdated()
        {
            // Arrange (preparation)
            int authorId = 1;
            AuthorService service = new AuthorService(_context, _mapper);
            UpdateAuthorDto authorToUpdate = new UpdateAuthorDto() { Name = "Eray", Surname = "Test", DateOfBirth = DateTime.Now.AddYears(-5) };

            // Act
            FluentActions.Invoking(() => service.UpdateAuthor(authorToUpdate, authorId)).Invoke();

            // Assert
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);

            author.Should().NotBeNull();
            author.Name.Should().Be(authorToUpdate.Name);
            author.Surname.Should().Be(authorToUpdate.Surname);
            author.DateOfBirth.Should().Be(authorToUpdate.DateOfBirth);
        }
    }
}
