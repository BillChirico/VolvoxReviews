using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Reviews;

namespace Volvox.Reviews.Domain.Models.Products.Movies
{
    public class Movie : Product
    { 
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
