using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Reviews;
using Volvox.Reviews.Service.Common;

namespace Volvox.Reviews.Service.Reviews
{
    public class ReviewService : EntityService<Review>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
            : base(reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Review GetById(int id)
        {
            return _reviewRepository.GetById(id);
        }

        public IEnumerable<Review> GetUsersReviews(string userId)
        {
            return _reviewRepository.FindBy(review => review.User.Id == userId);
        }

        public IEnumerable<Review> GetRecentReviews(int count)
        {
            return _reviewRepository.OrderByDescending<int>(review => review.Id, count);
        }
    }
}
