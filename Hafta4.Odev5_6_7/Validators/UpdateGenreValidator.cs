using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreDto>
    {
        public UpdateGenreValidator()
        {
            RuleFor(genre => genre.Name).MinimumLength(3).When(x => x.Name.Trim() != string.Empty);
        }
    }
}
