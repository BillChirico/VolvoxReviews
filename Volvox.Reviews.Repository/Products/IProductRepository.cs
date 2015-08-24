using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Repository.Common;

namespace Volvox.Reviews.Repository.Products
{
    public interface IProductRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        T GetById(int id);
    }
}
