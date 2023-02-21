using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistAuthorIsGiven_Exception_ShouldBeReturn()
        {
            // Arrange (preparation)
            AuthorService service = new AuthorService(_context, _mapper);
            CreateAuthorDto authorToCreate = new CreateAuthorDto() { Name = "Fyodor", Surname = "Dostoyevski", DateOfBirth = DateTime.UtcNow.AddYears(-2) };

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.AddAuthorAsync(authorToCreate))
                .Should().ThrowAsync<Exception>();
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            // Arrange (preparation)
            AuthorService service = new AuthorService(_context, _mapper);
            CreateAuthorDto authorToCreate = new CreateAuthorDto() { Name = "Eray", Surname = "Berberoğlu", DateOfBirth = DateTime.UtcNow.AddYears(-2) };

            // Act
            FluentActions.Invoking(async () => await service.AddAuthorAsync(authorToCreate)).Invoke();

            // Assert
            var author = _context.Authors.SingleOrDefault(x => x.Name == authorToCreate.Name);

            author.Should().NotBeNull();
            author.Name.Should().Be(authorToCreate.Name);
            author.Surname.Should().Be(authorToCreate.Surname);
            author.DateOfBirth.Should().Be(authorToCreate.DateOfBirth);
        }
    }
}
