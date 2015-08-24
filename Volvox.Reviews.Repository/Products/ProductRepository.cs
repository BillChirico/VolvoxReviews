using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Products
{
    public class ProductRepository<T> : GenericRepository<T>, IProductRepository<T> where T : BaseEntity
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }

        public T GetById(int id)
        {
            return Dbset.FirstOrDefault(product => product.);
        }
    }
}
