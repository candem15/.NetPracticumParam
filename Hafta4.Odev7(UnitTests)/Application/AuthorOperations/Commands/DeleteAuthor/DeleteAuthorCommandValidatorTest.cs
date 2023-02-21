using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int authorId)
        {
            // Arrange
            DeleteAuthorDto authorToDelete = new DeleteAuthorDto() { Id = authorId };

            // Act
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            var result = validator.Validate(authorToDelete);

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            DeleteAuthorDto authorToDelete = new DeleteAuthorDto() { Id = 1 };

            // Act
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            var result = validator.Validate(authorToDelete);

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }
    }
}
