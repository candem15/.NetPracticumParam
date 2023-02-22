using FluentValidation;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.UpdateActorActress
{
    public class UpdateActorActressCommandValidator : AbstractValidator<UpdateActorActressCommand>
    {
        public UpdateActorActressCommandValidator()
        {
            RuleFor(command => command.ActorActressId).GreaterThan(0);
        }
    }
}
