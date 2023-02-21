using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.BookOperations;

namespace Hafta4.Odev5_6_7.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookDto>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
