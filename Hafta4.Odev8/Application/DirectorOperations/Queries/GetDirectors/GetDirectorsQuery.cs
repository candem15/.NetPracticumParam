using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var directors = _dbContext.Directors.ToList();
            List<DirectorViewModel> vm = _mapper.Map<List<DirectorViewModel>>(directors);
            return vm;
        }

        public class DirectorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
