using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.CreateBook
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
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (preparation)
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", AuthorId = 1, GenreId = 1, PageCount = 2207, PublishDate = new System.DateTime(2022, 07, 22) };
            _context.Books.Add(book);
            _context.SaveChanges();

            BookService service = new BookService(_context, _mapper);
            CreateBookDto bookToCreate = new CreateBookDto() { Title = book.Title, PublishDate = DateTime.UtcNow, AuthorId = 1, GenreId = 1, PageCount = 100 };

            // Act & Assert (run and confirmation)
            FluentActions
                .Invoking(async () => await service.AddBookAsync(bookToCreate))
                .Should().ThrowAsync<Exception>().Result.WithMessage($"Book with title: {book.Title} already exists!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            // Arrange (preparation)
            BookService service = new BookService(_context, _mapper);
            CreateBookDto bookToCreate = new CreateBookDto() { Title = "Romeo&Juliet", PageCount = 150, PublishDate = DateTime.Now.Date.AddYears(-2), GenreId = 1 };

            // Act
            FluentActions.Invoking(() => service.AddBookAsync(bookToCreate)).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(x => x.Title == bookToCreate.Title);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(bookToCreate.PageCount);
            book.PublishDate.Should().Be(bookToCreate.PublishDate);
            book.GenreId.Should().Be(bookToCreate.GenreId);
        }
    }
}
