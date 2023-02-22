using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.ActorActressOperations.Queries.GetActorActressDetail
{
    public class GetActorActressDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int ActorActressId { get; set; }

        public GetActorActressDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActorActressDetailViewModel Handle()
        {
            var actorActress = _dbContext.ActorActress.Where(actorActress => actorActress.Id == ActorActressId).SingleOrDefault();
            if (actorActress == null)
            {
                throw new InvalidOperationException("Actor/Actress could not found!");
            }

            ActorActressDetailViewModel vm = _mapper.Map<ActorActressDetailViewModel>(actorActress);

            return vm;
        }

        public class ActorActressDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
