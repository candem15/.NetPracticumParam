using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.UpdateBook
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
        public void WhenGivenBookIdIsNotExist_InvalidOperationException_ShouldBeReturnErrors(int id)
        {
            // Arrange
            BookService service = new BookService(_context, _mapper);

            // Act and Assert
            FluentActions.Invoking(() => service.UpdateBook(new UpdateBookDto() { Id = id, Title = "Test" })).Should().Throw<BookNotExistsException>();
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            // Arrange (preparation)
            int bookId = 1;
            BookService service = new BookService(_context, _mapper);
            UpdateBookDto bookToUpdate = new UpdateBookDto() { Title = "Romeo&Juliet", Id = bookId };

            // Act
            FluentActions.Invoking(() => service.UpdateBook(bookToUpdate)).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);

            book.Should().NotBeNull();
            book.Title.Should().Be(bookToUpdate.Title);
        }
    }
}
