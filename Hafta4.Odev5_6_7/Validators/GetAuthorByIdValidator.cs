using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorDetailsDto>
    {
        public GetAuthorByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
