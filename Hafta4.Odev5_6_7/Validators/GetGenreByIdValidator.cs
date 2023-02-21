using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreDetailsDto>
    {
        public GetGenreByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
