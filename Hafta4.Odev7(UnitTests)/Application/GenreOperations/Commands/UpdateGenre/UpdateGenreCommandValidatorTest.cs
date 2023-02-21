using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Validators;

namespace Hafta4.Odev7_UnitTests_.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("ay")]
        [InlineData("         ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            // Arrange
            UpdateGenreDto genreToUpdate = new UpdateGenreDto()
            {
                Name = name
            };

            // Act
            UpdateGenreValidator validator = new UpdateGenreValidator();
            var result = validator.Validate(genreToUpdate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateGenreDto genreToUpdate = new UpdateGenreDto()
            {
                Name = "Fantasy"
            };

            // Act
            UpdateGenreValidator validator = new UpdateGenreValidator();
            var result = validator.Validate(genreToUpdate);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
