using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(99999)]
        public void WhenGivenAuthorIdIsNotExist_Exception_ShouldBeReturn(int authorId)
        {
            // Arrange (preparation)
            AuthorService service = new AuthorService(_context, _mapper);

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.DeleteAuthorAsync(authorId))
                .Should().ThrowAsync<AuthorNotExistsException>();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Author_ShouldBeDeleted(int authorId)
        {
            // Arrange (preparation)
            AuthorService service = new AuthorService(_context, _mapper);

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.DeleteAuthorAsync(authorId)).Invoke();

            // Assert 
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            author.Should().BeNull();
        }
    }
}
