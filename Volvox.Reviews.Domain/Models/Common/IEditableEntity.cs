using System;

namespace Volvox.Reviews.Domain.Models.Common
{
    public interface IEditableEntity
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}
