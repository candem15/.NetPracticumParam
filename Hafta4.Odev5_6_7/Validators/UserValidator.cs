using FluentValidation;
using Hafta4.Odev5_6_7.Entities;

namespace Hafta4.Odev5_6_7.Validators
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
