using FluentValidation;
using Hafta2.Odev2.Entities;

namespace Hafta2.Odev2.Validators
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
