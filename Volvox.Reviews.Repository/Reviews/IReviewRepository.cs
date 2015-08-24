using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Reviews
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Review GetById(int id);
    }
}
