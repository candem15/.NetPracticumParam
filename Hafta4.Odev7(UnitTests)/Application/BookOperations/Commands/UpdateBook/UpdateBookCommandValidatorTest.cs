using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(-99, "Lord Of The Rings")]
        [InlineData(0, "Lord Of The Rings")]
        [InlineData(3, "")]
        [InlineData(-1, "Lord Of The Rings")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId, string title)
        {
            // Arrange
            UpdateBookDto model = new UpdateBookDto()
            {
                Id = bookId,
                Title = title
            };

            // Act
            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(model);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateBookDto model = new UpdateBookDto()
            {
                Id = 1,
                Title = "Balzac"
            };

            // Act
            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(model);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
