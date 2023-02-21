using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int genreId)
        {
            // Act & Arrenge
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            var result = validator.Validate(new GetGenreDetailsDto { Id = genreId });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Act & Arrenge
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            var result = validator.Validate(new GetGenreDetailsDto { Id = 2 });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }
    }
}
