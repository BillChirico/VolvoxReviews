using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Reviews
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DbContext context)
            : base(context)
        {
            
        }

        public Review GetById(int id)
        {
            return Dbset.FirstOrDefault(review => review.Id == id);
        }
    }
}
