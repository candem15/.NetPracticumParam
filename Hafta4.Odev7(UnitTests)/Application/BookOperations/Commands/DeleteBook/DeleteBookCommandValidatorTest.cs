using AutoMapper;
using FluentAssertions;
using Hafta4.Odev5_6_7.DbOperations;
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

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int bookId)
        {
            // Arrange
            DeleteBookDto bootToDelete = new DeleteBookDto() { Id = bookId };

            // Act
            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(bootToDelete);

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            DeleteBookDto bootToDelete = new DeleteBookDto() { Id = 25 };

            // Act
            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(bootToDelete);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
