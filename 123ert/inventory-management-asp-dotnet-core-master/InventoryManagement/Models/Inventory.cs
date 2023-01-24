using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Inventory
    {
        public long Id { get; set; }
        public int Pid { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
