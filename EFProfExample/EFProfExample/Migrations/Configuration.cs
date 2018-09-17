using Bogus;
using EFProfExample.Models;

namespace EFProfExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFProfExample.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFProfExample.Models.DataContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Faker<Category>()
                .RuleFor(c => c.Name, (f, c) => f.Commerce.Categories(1).First())
                .Generate(10);

            context.Categories.AddRange(categories);

            var products = new Faker<Product>()
                .RuleFor(p => p.Name, (f, p) => f.Commerce.Product())
                .RuleFor(p => p.Category, (f, p) => f.PickRandom(categories))
                .Generate(100);

            context.Products.AddRange(products);

            context.SaveChanges();
        }
    }
}
