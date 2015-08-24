using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Volvox.Reviews.Domain.Models.Reviews;

namespace Volvox.Reviews.Domain.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Reviews submited by the user
        /// </summary>
        public virtual IEnumerable<Review> Reviews { get; set; }
    }
}