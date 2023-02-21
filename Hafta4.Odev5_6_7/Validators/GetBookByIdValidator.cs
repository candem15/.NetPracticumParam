using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.BookOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class GetBookByIdValidator : AbstractValidator<GetBookDetailsDto>
    {
        public GetBookByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
