using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreDto>
    {
        public CreateGenreValidator()
        {
            RuleFor(genre => genre.Name).NotEmpty().MinimumLength(3);
        }
    }
}
