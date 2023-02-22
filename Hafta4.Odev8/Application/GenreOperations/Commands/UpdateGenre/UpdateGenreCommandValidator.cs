using FluentValidation;

namespace Hafta4.Odev8.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreTitle).NotEmpty().MinimumLength(3);
        }
    }
}
