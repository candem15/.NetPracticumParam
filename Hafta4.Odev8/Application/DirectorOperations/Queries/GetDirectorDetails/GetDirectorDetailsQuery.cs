using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _dbContext.Directors.Where(director => director.Id == DirectorId).FirstOrDefault();

            if (director == null)
            {
                throw new InvalidOperationException($"Director with id: {DirectorId} not exists!");
            }

            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);

            return vm;
        }

        public class DirectorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

    }
}
