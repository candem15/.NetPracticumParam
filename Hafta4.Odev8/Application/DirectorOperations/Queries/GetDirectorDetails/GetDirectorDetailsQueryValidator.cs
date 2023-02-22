using FluentValidation;

namespace Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(query => query.DirectorId).GreaterThan(0);
        }
    }
}
