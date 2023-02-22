using AutoMapper;
using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public DeleteMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException($"Movie with id: {MovieId} not exists!");
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}
