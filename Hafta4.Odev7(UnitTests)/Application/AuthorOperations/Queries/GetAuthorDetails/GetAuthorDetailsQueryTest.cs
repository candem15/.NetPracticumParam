﻿using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(55)]
        [InlineData(9999)]
        public async Task WhenAuthorIdIsNotFound_AuthorNotExistsException_ShouldReturnError(int id)
        {
            AuthorService service = new AuthorService(_context, _mapper);
            await FluentActions.Invoking(async () => await service.GetAuthorByIdAsync(id))
                .Should().ThrowAsync<AuthorNotExistsException>();
        }
    }
}
