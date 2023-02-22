using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.UpdateActorActress
{
    public class UpdateActorActressCommand
    {
        public UpdateActorActressModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int ActorActressId { get; set; }

        public UpdateActorActressCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actorActress = _dbContext.ActorActress.SingleOrDefault(x => x.Id == ActorActressId);

            if (actorActress == null)
            {
                throw new InvalidOperationException($"Actor with id: {ActorActressId} not exists!");
            }

            _mapper.Map(Model, actorActress);
            _dbContext.SaveChanges();
        }


        public class UpdateActorActressModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
