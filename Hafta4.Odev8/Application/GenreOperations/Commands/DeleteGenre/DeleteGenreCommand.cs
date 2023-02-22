﻿using Hafta4.Odev8.DbOperations;

namespace Hafta4.Odev8.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException($"Genre with id: {GenreId} not exists!");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
