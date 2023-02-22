using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.ActorActressOperations.Commands.DeleteActorActress
{
    public class DeleteActorActressCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public int ActorActressId { get; set; }

        public DeleteActorActressCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actorActress = _dbContext.ActorActress.SingleOrDefault(x => x.Id == ActorActressId);

            if (actorActress == null)
            {
                throw new InvalidOperationException($"Actor with id: {ActorActressId} not exists, cannot delete it!");
            }

            _dbContext.ActorActress.Remove(actorActress);
            _dbContext.SaveChanges();

        }
    }

}
