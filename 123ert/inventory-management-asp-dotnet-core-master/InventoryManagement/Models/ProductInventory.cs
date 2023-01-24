using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductInventory
    {
        public long Id { get; set; }
        public int Pid { get; set; }
        public long InventotyId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
