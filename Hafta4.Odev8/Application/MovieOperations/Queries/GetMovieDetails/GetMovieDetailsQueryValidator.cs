using FluentValidation;

namespace Hafta4.Odev8.Application.MovieOperations.Queries.GetMovieDetails
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(query => query.MovieId).GreaterThan(0);
        }
    }
}
