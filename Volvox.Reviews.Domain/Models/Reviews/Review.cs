using System.ComponentModel.DataAnnotations;
using Volvox.Reviews.Domain.Models.Common;
using Volvox.Reviews.Domain.Models.Identity;
using Volvox.Reviews.Domain.Models.Products;
using Volvox.Reviews.Domain.Models.Products.Movies;

namespace Volvox.Reviews.Domain.Models.Reviews
{
    public class Review : EditableEntity<int>
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Range(1.0, 10.0)]
        public double Rating { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}