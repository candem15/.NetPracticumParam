using AutoMapper;
using Hafta4.Odev5_6_7.DbOperations;
using Hafta4.Odev5_6_7.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta4.Odev7_UnitTests_.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var operations = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreDb").Options;
            Context = new BookStoreDbContext(operations);

            // Db created and moq datas added to it.
            Context.Database.EnsureCreated();
            Context.AddGenres();
            Context.AddAuthors();
            Context.AddBooks();

            Context.SaveChanges();

            // Automapper profiles included.
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookMappings>();
                cfg.AddProfile<AuthorMappings>();
                cfg.AddProfile<GenreMappings>();
            }).CreateMapper();
        }
    }
}
