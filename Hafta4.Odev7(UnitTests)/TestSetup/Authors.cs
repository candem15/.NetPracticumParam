using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Entities;

namespace Hafta4.Odev7_UnitTests_.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.AddRange(
                    new Author { Name = "Fyodor", Surname = "Dostoyevski", DateOfBirth = new DateTime(1821, 11, 11) },
                    new Author { Name = "Jean Paul", Surname = "Sartre", DateOfBirth = new DateTime(1905, 06, 21) },
                    new Author { Name = "Albert", Surname = "Camus", DateOfBirth = new DateTime(1913, 11, 07) },
                    new Author { Name = "Enes", Surname = "Arat", DateOfBirth = new DateTime(1999, 07, 07) }
                );
        }
    }
}
