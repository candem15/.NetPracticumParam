using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("ay")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            // Arrange
            CreateGenreDto genreToCreate = new CreateGenreDto()
            {
                Name = name
            };

            // Act
            CreateGenreValidator validator = new CreateGenreValidator();
            var result = validator.Validate(genreToCreate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            CreateGenreDto genreToCreate = new CreateGenreDto()
            {
                Name = "Fantasy"
            };

            // Act
            CreateGenreValidator validator = new CreateGenreValidator();
            var result = validator.Validate(genreToCreate);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
