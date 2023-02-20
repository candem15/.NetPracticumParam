using FluentValidation;
using Hafta3.Odev3_4.Entities;

namespace Hafta3.Odev3_4.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).GreaterThan(1);
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
