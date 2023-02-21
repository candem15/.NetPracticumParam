using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteBookCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(99999)]
        public void WhenGivenBookIdIsNotExist_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            // Arrange (preparation)
            BookService service = new BookService(_context, _mapper);

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.DeleteBook(bookId))
                .Should().ThrowAsync<BookToDeleteNotExistsException>();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted(int bookId)
        {
            // Arrange (preparation)
            BookService service = new BookService(_context, _mapper);

            // Act
            FluentActions
               .Invoking(async () => await service.DeleteBook(bookId)).Invoke();

            // Assert 
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            book.Should().BeNull();
        }
    }
}
