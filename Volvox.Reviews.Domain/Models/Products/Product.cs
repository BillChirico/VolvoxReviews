using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Reviews;

namespace Volvox.Reviews.Domain.Models.Products
{
    public class Product : EditableEntity<int>
    {
        public virtual IEnumerable<Review> Reviews { get; set; }
    }
}
