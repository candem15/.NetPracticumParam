using FluentValidation;

namespace Hafta4.Odev8.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreTitle).NotEmpty().MinimumLength(3);
        }
    }
}
