using FluentValidation;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.DeleteActorActress
{
    public class DeleteActorActressCommandValidator : AbstractValidator<DeleteActorActressCommand>
    {
        public DeleteActorActressCommandValidator()
        {
            RuleFor(command => command.ActorActressId).GreaterThan(0);
        }
    }
}
