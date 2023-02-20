using FluentValidation;
using Hafta3.Odev3_4.Dtos.BookOperations;
using Hafta3.Odev3_4.Entities;

namespace Hafta3.Odev3_4.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MinimumLength(1);
        }
    }
}
