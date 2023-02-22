using FluentValidation;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.CreateActorActress
{
    public class CreateActorActressCommandValidator : AbstractValidator<CreateActorActressCommand>
    {
        public CreateActorActressCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
        }
    }
}
