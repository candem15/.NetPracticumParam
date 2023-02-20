using AutoMapper;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.AuthorOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev5_6_7.Services
{
    public class AuthorService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AuthorService(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Add new book to db by given fields.
        public async Task<int> AddAuthorAsync(CreateAuthorDto book)
        {
            var bookToAdd = mapper.Map<Book>(book);

            await context.Books.AddAsync(bookToAdd);
            await context.SaveChangesAsync();

            return bookToAdd.Id;
        }

        // Updates existing author at Db.
        public void UpdateAuthor(UpdateAuthorDto author, int id)
        {
            var authorToUpdate = context.Authors.Find(id);
            authorToUpdate = mapper.Map<Author>(authorToUpdate);

            context.Authors.Update(authorToUpdate);
            context.SaveChanges();
        }

        // Returns all authors at Db.
        public async Task<List<GetAuthorViewModel>> GetAuthorsAsync()
        {
            // "Author" list to "GetAuthorViewModel" list mapping done.
            List<Author> authors = await context.Authors.ToListAsync();

            List<GetAuthorViewModel> authorsViewModel = new();
            authorsViewModel = mapper.Map<List<GetAuthorViewModel>>(authors);

            return authorsViewModel;
        }

        // Returns author that match given id.
        public async Task<GetAuthorViewModel> GetAuthorByIdAsync(int id)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null)
                throw new AuthorNotExistsException(id);

            return mapper.Map<GetAuthorViewModel>(author);
        }

        // Deletes author from db.
        public async Task DeleteAuthorAsync(int id)
        {
            var authorToDelete = await context.Authors.FindAsync(id);

            if (authorToDelete == null)
                throw new AuthorNotExistsException(id);

            context.Authors.Remove(authorToDelete);

            await context.SaveChangesAsync();
        }
    }
}
