using AutoMapper;
using Hafta3.Odev3_4.DbOperations;
using Hafta3.Odev3_4.Dtos.BookOperations;
using Hafta3.Odev3_4.Entities;
using Hafta3.Odev3_4.Exceptions;
using Hafta3.Odev3_4.Extensions;
using Hafta3.Odev3_4.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hafta3.Odev3_4.Services
{
    public class BookService
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public BookService(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Add new book to db by given fields.
        public async Task<int> AddBookAsync(CreateBookDto book)
        {
            var bookToAdd = mapper.Map<Book>(book);

            await context.Books.AddAsync(bookToAdd);
            await context.SaveChangesAsync();

            return bookToAdd.Id;
        }

        // Updates existing book at Db.
        public void UpdateBook(UpdateBookDto book)
        {
            var bookToUpdate = context.Books.Find(book.Id);
            bookToUpdate = mapper.Map<Book>(book);

            context.Books.Update(bookToUpdate);
            context.SaveChanges();
        }

        // Returns all books at Db.
        public async Task<GetBooksViewModel> GetBooksAsync()
        {
            // "Book" list to "GetBookViewModel" list mapping done.
            List<Book> books = await context.Books.ToListAsync();

            GetBooksViewModel booksViewModel = new();
            booksViewModel.Books = mapper.Map<List<GetBookViewModel>>(books);

            return booksViewModel;
        }

        // Returns book that match given id.
        public async Task<GetBookViewModel> GetBookByIdAsync(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new BookNotExistsException(id);

            return mapper.Map<GetBookViewModel>(book);
        }

        // Deletes book from db.
        public async Task DeleteBook(int id)
        {
            var bookToDelete = await context.Books.FindAsync(id);

            if (bookToDelete == null)
                throw new BookToDeleteNotExistsException(id);

            context.Books.Remove(bookToDelete);

            await context.SaveChangesAsync();
        }

        // Search books from db by given words and returns matched ones with order option.
        public async Task<GetBooksViewModel> GetFilteredBooksWithOrderAsync(string filter, string orderby = "asc")
        {
            try
            {
                var books = new List<Book>();
                if (orderby == "asc")
                    books = await context.Books.OrderBy<Book>(filter).ToListAsync();
                else
                    books = await context.Books.OrderByDescending<Book>(filter).ToListAsync();

                GetBooksViewModel booksViewModel = new();
                booksViewModel.Books = mapper.Map<List<GetBookViewModel>>(books);
                return booksViewModel;
            }
            catch
            {
                throw new WrongParameterEnteredForFilterBooksException();
            }
        }

        // Search books from db by its title and returns matched ones.
        public async Task<GetBooksViewModel> SearchBooksByTitleAsync(string title)
        {
            var books = await context.Books.Where(x => x.Title.Contains(title)).ToListAsync();

            if (books == null)
                throw new SearchBooksByTitleException(title);

            GetBooksViewModel booksViewModel = new();
            booksViewModel.Books = mapper.Map<List<GetBookViewModel>>(books);
            return booksViewModel;
        }
    }
}
