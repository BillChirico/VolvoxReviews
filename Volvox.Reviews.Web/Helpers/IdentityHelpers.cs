using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Web.Models;

namespace Volvox.Reviews.Web.Helpers
{
    public static class IdentityHelpers
    {
        public static Task<IdentityResult> RemeberLoginDateTime(this ApplicationUserManager manager, ApplicationUser user)
        {
            user.LastLogin = DateTime.UtcNow;
            return manager.UpdateAsync(user);
        }
    }
}