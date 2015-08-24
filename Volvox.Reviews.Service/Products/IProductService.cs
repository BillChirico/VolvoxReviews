using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Service.Common;

namespace Volvox.Reviews.Service.Products
{
    public interface IProductService<T> : IEntityService<T> where T : BaseEntity
    {
        T GetById(int id);
    }
}
