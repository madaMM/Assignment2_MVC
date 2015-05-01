namespace MvcAppShop.Migrations
{
    using MvcAppShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcAppShop.Models.ProductDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcAppShop.Models.ProductDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Products.AddOrUpdate(
                 p => p.Name,
                 new Product { Name = "Pencil", Price = 5.12M },
                   new Product { Name = "Brush", Price = 6.13M },
                   new Product { Name = "Rubber", Price = 7.89M }
                 );
        }
    }
}
