using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorDto>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
