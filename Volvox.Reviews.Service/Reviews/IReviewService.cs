using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Service.Common;

namespace Volvox.Reviews.Service.Reviews
{
    public interface IReviewService : IEntityService<Review>
    {
        Review GetById(int id);

        IEnumerable<Review> GetUsersReviews(string userId);

        IEnumerable<Review> GetRecentReviews(int count);
    }
}
