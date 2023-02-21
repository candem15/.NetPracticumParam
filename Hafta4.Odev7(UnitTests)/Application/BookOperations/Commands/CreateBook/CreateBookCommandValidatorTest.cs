using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev5_6_7.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.CreateBook
{
    public class CreateAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData("Lord Of The Rings", 0, 0, 0)]
        [InlineData("Lord Of The Rings", 0, 1, 1)]
        [InlineData("", 0, 0, 0)]
        [InlineData("Lord Of The Rings", 1, 200, 20)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            // Arrange
            CreateBookDto bookToCreate = new CreateBookDto()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId,
                AuthorId = authorId
            };

            // Act
            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(bookToCreate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            // Arrange
            CreateBookDto bookToCreate = new CreateBookDto()
            {
                Title = "28.harf",
                PageCount = 2207,
                PublishDate = DateTime.Now.Date,
                GenreId = 1,
                AuthorId = 1
            };

            // Act
            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(bookToCreate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            CreateBookDto bookToCreate = new CreateBookDto()
            {
                Title = "28.harf",
                PageCount = 2207,
                PublishDate = DateTime.Now.Date.AddDays(-2),
                GenreId = 1,
                AuthorId = 1
            };

            // Act
            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(bookToCreate);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
