using System;
using System.ComponentModel.DataAnnotations;

namespace Volvox.Reviews.Domain.Models.Common
{
    /// <summary>
    /// Type of entity that is editable. This type of entity will automatically update Created and Updated properties
    /// </summary>
    /// <typeparam name="T">Type of Id</typeparam>
    public abstract class EditableEntity<T> : Entity<T>, IEditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
