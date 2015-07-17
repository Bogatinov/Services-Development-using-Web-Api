namespace Cinema.Migrations
{
    using Cinema.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cinema.Models.CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cinema.Models.CinemaContext context)
        {
            context.Foods.Add(new Food()
            {
                Name = "Popcorn",
                Price = 23.99
            });
            context.Foods.Add(new Food()
            {
               Name = "Cheetoz",
               Price = 5.99
            });
            context.Foods.Add(new Food()
            {
                Name = "M&M",
                Price = 149.99
            });
            context.Drinks.Add(new Drink()
            {
                Liters = 0.5,
                Name = "Banana Smoothie",
                Price = 0.99
            });
            context.Drinks.Add(new Drink()
            {
                Liters = 0.22,
                Name = "Sex On the Beach",
                Price = 1.99
            });
        }
    }
}
