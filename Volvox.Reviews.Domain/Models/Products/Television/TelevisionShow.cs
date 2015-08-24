using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvox.Reviews.Domain.Models.Products.Television
{
    public class TelevisionShow : Product
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Network { get; set; }
    }
}
