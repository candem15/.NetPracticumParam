using FluentValidation;
using Hafta3.Odev3_4.Dtos.BookOperations;

namespace Hafta3.Odev3_4.Validators
{

    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(1);
            RuleFor(x => x.PageCount).NotEmpty().InclusiveBetween(1, 1000000);
            RuleFor(x => x.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }

}
