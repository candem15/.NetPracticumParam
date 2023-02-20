using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(1);
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
