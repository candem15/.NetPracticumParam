using AutoMapper;
using Hafta4.Odev8.DbOperations;
using Hafta4.Odev8.Entities;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.CreateActorActress
{
    public class CreateActorActressCommand
    {
        public CreateActorActressModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public CreateActorActressCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actorActress = _context.ActorActress.SingleOrDefault(x => x.Name == Model.Name);
            if (actorActress != null)
            {
                throw new InvalidOperationException("Actor is already exists!");
            }

            actorActress = _mapper.Map<ActorActress>(Model);

            _context.ActorActress.Add(actorActress);
            _context.SaveChanges();
        }

        public class CreateActorActressModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
