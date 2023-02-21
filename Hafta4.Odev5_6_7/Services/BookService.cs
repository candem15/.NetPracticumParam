using AutoMapper;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Dtos.BookOperations;
using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Exceptions;
using Hafta4.Odev5_6_7.Extensions;
using Hafta4.Odev5_6_7.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev5_6_7.Services
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
            if (context.Books.Any(x => x.Title == book.Title))
                throw new Exception($"Book with title: {book.Title} already exists!");

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
            List<Book> books = await context.Books.Include(x => x.Genre).Include(x => x.Author).ToListAsync();

            GetBooksViewModel booksViewModel = new();
            booksViewModel.Books = mapper.Map<List<GetBookViewModel>>(books);

            return booksViewModel;
        }

        // Returns book that match given id.
        public async Task<GetBookViewModel> GetBookByIdAsync(int id)
        {
            var book = await context.Books.Include(x => x.Genre).Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);

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
                    books = await context.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy<Book>(filter).ToListAsync();
                else
                    books = await context.Books.Include(x => x.Genre).Include(x => x.Author).OrderByDescending<Book>(filter).ToListAsync();

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
            var books = await context.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Title.Contains(title)).ToListAsync();

            if (books == null)
                throw new SearchBooksByTitleException(title);

            GetBooksViewModel booksViewModel = new();
            booksViewModel.Books = mapper.Map<List<GetBookViewModel>>(books);
            return booksViewModel;
        }
    }
}
