using FluentValidation;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Dtos.BookOperations;

namespace Hafta4.Odev5_6_7.Validators
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
