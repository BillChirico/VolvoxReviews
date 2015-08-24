using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Domain.Models.Products.Television;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Web.Models;

namespace Volvox.Reviews.Web.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Reviews
        public DbSet<Review> Reviews { get; set; }

        // Movies
        public DbSet<Movie> Movies { get; set; }

        // Television
        public DbSet<TelevisionShow> TelevisionShows { get; set; }

        // Products
        public DbSet<Product> Products { get; set; } 

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IEditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IEditableEntity;

                if (entity != null)
                {
                    var identityName = Thread.CurrentPrincipal.Identity.GetUserId();
                    var now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }

                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}