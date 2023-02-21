using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Entities;

namespace Hafta4.Odev7_UnitTests_.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book { Title = "Lean Startup", GenreId = 1, AuthorId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
                    new Book { Title = "Herland", GenreId = 2, AuthorId = 2, PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
                    new Book { Title = "Dune", GenreId = 2, AuthorId = 3, PageCount = 540, PublishDate = new DateTime(2001, 12, 21) },
                    new Book { Title = "28.Harf", GenreId = 2, AuthorId = 4, PageCount = 2207, PublishDate = new DateTime(2022, 07, 22) }
                );
        }
    }
}
