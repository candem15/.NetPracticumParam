using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.ActorActressOperations.Queries.GetActorsAndActresses
{
    public class GetActorActressQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorActressQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorActressViewModel> Handle()
        {
            var actorActressList = _dbContext.ActorActress.ToList();
            List<ActorActressViewModel> vm = _mapper.Map<List<ActorActressViewModel>>(actorActressList);
            return vm;
        }

        public class ActorActressViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
