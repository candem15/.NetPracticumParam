using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Queries.GetBookDetails
{
    public class GetBookDetailsQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(55)]
        [InlineData(9999)]
        public async Task WhenBookIdIsNotFound_InvalidOperationException_ShouldReturnError(int id)
        {
            BookService _bookService = new BookService(_context, _mapper);
            await FluentActions.Invoking(async () => await _bookService.GetBookByIdAsync(id)).Should().ThrowAsync<BookNotExistsException>();

        }
    }
}
