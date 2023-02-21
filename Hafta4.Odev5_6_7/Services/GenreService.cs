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
        private readonly IMapper mapper;

        public GenreService(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
            if (context.Genres.Any(x => x.Name == genre.Name))
                throw new Exception("Genre to create is already exists!");

            var genreToAdd = mapper.Map<Genre>(genre);

            await context.Genres.AddAsync(genreToAdd);
            await context.SaveChangesAsync();
        }

        // Updates existing genre at Db.
        public void UpdateGenre(UpdateGenreDto genre, int id)
        {
            if (!context.Genres.Any(x => x.Id == id) || context.Genres.Any(x => x.Name == genre.Name))
                throw new Exception("Genre with given name already exists or wrong id entered!");

            var genreToUpdate = context.Genres.Where(x => x.Id == id).FirstOrDefault();
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
