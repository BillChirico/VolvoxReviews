using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Common;
using Volvox.Reviews.Service.Common;
using Volvox.Reviews.Service.Reviews;

namespace Volvox.Reviews.Service.Products
{
    public class ProductService<T> : EntityService<T>, IProductService<T> where T : BaseEntity
    {
        private readonly IReviewRepository _reviewRepository;

        public ProductService(IReviewRepository reviewRepository)
            : base(reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
