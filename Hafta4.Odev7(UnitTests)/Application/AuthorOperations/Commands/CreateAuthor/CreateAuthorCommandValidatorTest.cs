using FluentAssertions;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Services;
using Hafta4.Odev5_6_7.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTest
    {
        [Theory]
        [InlineData("", "", "")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, DateTime date)
        {
            // Arrange
            CreateAuthorDto authorToCreate = new CreateAuthorDto()
            {
                Name = name,
                Surname = surname,
                DateOfBirth = date
            };

            // Act
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(authorToCreate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateOfBirthIsGivenInvalid_Validator_ShouldBeReturnError()
        {
            // Arrange
            CreateAuthorDto authorToCreate = new CreateAuthorDto()
            {
                Name = "kam",
                Surname = "tengri",
                DateOfBirth = DateTime.Now.AddYears(3)
            };

            // Act
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(authorToCreate);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            CreateAuthorDto authorToCreate = new CreateAuthorDto()
            {
                Name = "kam",
                Surname = "tengri",
                DateOfBirth = DateTime.Now.AddYears(-5)
            };

            // Act
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(authorToCreate);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
