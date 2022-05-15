using System;

namespace DataModel.Models.Common
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
