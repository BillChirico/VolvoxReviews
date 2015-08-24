using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Web.Models;

namespace Volvox.Reviews.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Volvox.Reviews.Web.Contexts.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Volvox.Reviews.Web.Contexts.ApplicationDbContext context)
        {
            // Add admin role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                // Create the admin role
                manager.Create(role);
            }

            // Add default user
            if (!context.Users.Any(u => u.UserName == "Bapes"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "Bapes", Email = "billchirico@gmail.com" };

                // Create the user and add to the Admin role
                userManager.Create(user, "Abc123");
                userManager.AddToRole(user.Id, "Admin");

                // Add test movie
                var m = new Movie() { Title = "Test Movie One", Description = "Test Description One" };

                context.Movies.AddOrUpdate(m);

                context.SaveChanges();

                var r = new Review() { Title = "Test Review One", Body = "Test Review Body One", Rating = 1, User = user, ProductId = m.Id, Product = m, CreatedBy = user.Id };
                m.Reviews = context.Reviews.ToList();

                // Add test reviews
                context.Reviews.AddOrUpdate(p => p.Title,
                r,
                new Review() { Title = "Test Review Two", Body = "Test Review Body Two", Rating = 5, User = user, CreatedBy = user.Id },
                new Review() { Title = "Test Review Three", Body = "Test Review Body Three", Rating = 10, User = user, CreatedBy = user.Id });
            }
        }
    }
}
