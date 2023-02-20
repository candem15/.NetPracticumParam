using AutoMapper;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.GenreOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev5_6_7.Services
{
    public class GenreService
    {
        private readonly BookStoreDbContext context;
        private readonly ILogger<GenreService> logger;
        private readonly IMapper mapper;

        public GenreService(BookStoreDbContext context, IMapper mapper, ILogger<GenreService> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        // Return all genres.
        public async Task<List<GetGenreViewModel>> GetGenresAsync()
        {
            List<Genre> genres = await context.Genres.ToListAsync();

            GetGenreViewModel genresViewModel = new();
            List<GetGenreViewModel> result = mapper.Map<List<GetGenreViewModel>>(genres);

            return result;
        }

        // Returns genre that match given id.
        public async Task<GetGenreViewModel> GetGenreByIdAsync(int id)
        {
            var genre = await context.Genres.FindAsync(id);

            if (genre == null)
                throw new GenreNotExistsException(id);

            return mapper.Map<GetGenreViewModel>(genre);
        }

        // Add new genre to db by given fields.
        public async Task AddGenreAsync(CreateGenreDto genre)
        {
            var genreToAdd = mapper.Map<Genre>(genre);

            await context.Genres.AddAsync(genreToAdd);
            await context.SaveChangesAsync();
        }

        // Updates existing genre at Db.
        public void UpdateGenre(UpdateGenreDto genre)
        {
            var genreToUpdate = context.Genres.Where(x=>x.Name==genre.Name).FirstOrDefault();
            genreToUpdate = mapper.Map<Genre>(genre);

            context.Genres.Update(genreToUpdate);
            context.SaveChanges();
        }

        // Deletes genre from db.
        public async Task DeleteGenreAsync(int id)
        {
            var genreToDelete = await context.Genres.FindAsync(id);

            if (genreToDelete == null)
                throw new GenreToDeleteNotExistsException(id);

            context.Genres.Remove(genreToDelete);

            await context.SaveChangesAsync();
        }


    }
}
