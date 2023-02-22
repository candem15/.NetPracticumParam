﻿using Hafta4.Odev8.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hafta4.Odev8.DbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }

        public DbSet<ActorActress> ActorActress { get; set; }
        public DbSet<ActorActressMovieJoint> actorActressMovieJoints { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
