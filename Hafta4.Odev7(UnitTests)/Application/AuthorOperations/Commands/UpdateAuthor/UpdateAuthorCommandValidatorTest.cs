using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-99, "test", "test")]
        [InlineData(0, "test", "test")]
        [InlineData(3, "", "")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId, string name, string surname)
        {
            // Arrange
            UpdateAuthorDto model = new UpdateAuthorDto()
            { Name = name, Surname = surname, DateOfBirth = DateTime.Now.AddYears(-5) };

            // Act
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(model);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateAuthorDto model = new UpdateAuthorDto()
            { Name = "Eray", Surname = "Test", DateOfBirth = DateTime.Now.AddYears(-5) };

            // Act
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(model);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
