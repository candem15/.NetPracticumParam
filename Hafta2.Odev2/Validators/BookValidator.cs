using FluentValidation;
using Hafta2.Odev2.Entities;

namespace Hafta2.Odev2.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MinimumLength(1);
            RuleFor(x => x.PageCount).NotEmpty().InclusiveBetween(1, 1000000);
            RuleFor(x => x.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
