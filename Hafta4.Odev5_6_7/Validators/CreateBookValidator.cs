using FluentValidation;
using Hafta4.Odev5_6_7.Dtos.BookOperations;

namespace Hafta4.Odev5_6_7.Validators
{

    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(1);
            RuleFor(x => x.PageCount).NotEmpty().InclusiveBetween(1, 1000000);
            RuleFor(x => x.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x => x.GenreId).GreaterThan(0);
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }

}
