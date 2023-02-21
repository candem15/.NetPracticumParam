using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Validators;
using Hafta4.Odev7_UnitTests_.TestSetup;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-999)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        public void WhenLowerThanAndEqualToZeroIdIsGiven_Validator_ShouldBeReturnError(int authorId)
        {
            // Act & Arrenge
            GetAuthorByIdValidator validator = new GetAuthorByIdValidator();
            var result = validator.Validate(new GetAuthorDetailsDto { Id = authorId });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Act & Arrenge
            GetAuthorByIdValidator validator = new GetAuthorByIdValidator();
            var result = validator.Validate(new GetAuthorDetailsDto { Id = 2 });

            // Assert
            result.Errors.Count.Should().NotBe(0);
        }
    }
}
