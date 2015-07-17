using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("CinemaContext")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasMany(m => m.Tickets)
                .WithRequired(t => t.Movie)
                .HasForeignKey(t => t.MovieId);
        }
    }
}