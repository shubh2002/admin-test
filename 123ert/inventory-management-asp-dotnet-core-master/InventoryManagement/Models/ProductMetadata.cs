using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductMetadata
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
