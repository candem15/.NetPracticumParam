using Hafta2.Odev2.DbOperations;
using Hafta2.Odev2.Entities;
using Hafta2.Odev2.Exceptions;
using Hafta2.Odev2.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Hafta2.Odev2.Services
{
    public class BookService
    {
        private readonly BookStoreDbContext context;

        public BookService(BookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public void UpdateBook(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new BookNotExistsException(id);

            return book;
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await context.Books.FindAsync(id);

            if (bookToDelete == null)
                throw new BookToDeleteNotExistsException(id);

            context.Books.Remove(bookToDelete);

            await context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetFilteredBooksWithOrderAsync(string filter, string orderby = "asc")
        {
            try
            {
                var books = new List<Book>();
                if (orderby == "asc")
                    books = await context.Books.OrderBy<Book>(filter).ToListAsync();
                else
                    books = await context.Books.OrderByDescending<Book>(filter).ToListAsync();
                return books;
            }
            catch
            {
                throw new WrongParameterEnteredForFilterBooksException();
            }
        }

        public async Task<List<Book>> SearchBooksByTitleAsync(string title)
        {
            var books = await context.Books.Where(x => x.Title.Contains(title)).ToListAsync();

            if (books == null)
                throw new SearchBooksByTitleException(title);

            return books;
        }
    }
}
