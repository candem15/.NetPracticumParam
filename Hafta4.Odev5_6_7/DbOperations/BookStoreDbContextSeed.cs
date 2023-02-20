using Hafta4.Odev5_6_7.Entities;
using Hafta4.Odev5_6_7.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev5_6_7.DbOperations
{
    public class BookStoreDbContextSeed
    {
        public static void Seed(IServiceProvider provider)
        {
            using (var context = new BookStoreDbContext(provider.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() && context.Users.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Personal Growth"
                   },
                   new Genre
                   {
                       Name = "Science Fiction"
                   },
                   new Genre
                   {
                       Name = "Fantasy"
                   }
               );

                context.Users.AddRange(
                    new User()
                    {
                        Id = 1,
                        Name = "Eray",
                        Username = "eraybrbr",
                        Age = 27,
                        Password = PasswordHasherExtension.HashPasword("eray123.")
                    }, new User()
                    {
                        Id = 2,
                        Name = "Emel",
                        Username = "practicum35",
                        Age = 39,
                        Password = PasswordHasherExtension.HashPasword("35practicum")
                    }, new User()
                    {
                        Id = 3,
                        Name = "Ahmet",
                        Username = "gollum",
                        Age = 19,
                        Password = PasswordHasherExtension.HashPasword("lotr1923")
                    });

                context.Books.AddRange(
                    new Book()
                    {
                        Id = 1,
                        Title = "A Game of Thrones",
                        PageCount = 694,
                        PublishDate = new DateTime(1996, 8, 1),
                        GenreId = 3,
                        AuthorId = 1
                    },
                    new Book()
                    {
                        Id = 2,
                        Title = "A Clash of Kings",
                        PageCount = 761,
                        PublishDate = new DateTime(1999, 11, 16),
                        GenreId = 3,
                        AuthorId = 1
                    },
                    new Book()
                    {
                        Id = 3,
                        Title = "A Storm of Swords",
                        PageCount = 973,
                        PublishDate = new DateTime(2001, 8, 8),
                        GenreId = 3,
                        AuthorId = 1
                    },
                    new Book()
                    {
                        Id = 4,
                        Title = "Dune",
                        PageCount = 412,
                        PublishDate = new DateTime(1965, 8, 5),
                        GenreId = 2,
                        AuthorId = 2
                    },
                    new Book()
                    {
                        Id = 5,
                        Title = "God Emperor of Dune",
                        PageCount = 496,
                        PublishDate = new DateTime(1981, 5, 28),
                        GenreId = 2,
                        AuthorId = 2
                    });

                context.Authors.AddRange(
                   new Author
                   {
                       Name = "George",
                       Surname = "Raymond Richard Martin",
                       DateOfBirth = new DateTime(1970, 01, 12)
                   },
                   new Author
                   {
                       Name = "Frank",
                       Surname = "Herbert",
                       DateOfBirth = new DateTime(1965, 01, 12)
                   }
               );

                context.SaveChangesAsync();
            }
        }
    }
}
