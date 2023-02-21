using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.BookOperations.Queries.GetBookDetails
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int bookId)
        {
            // Act & Arrenge
            GetBookByIdValidator validator = new GetBookByIdValidator();
            var result = validator.Validate(new GetBookDetailsDto { Id = bookId });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Act & Arrenge
            GetBookByIdValidator validator = new GetBookByIdValidator();
            var result = validator.Validate(new GetBookDetailsDto { Id = 2 });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }
    }
}
