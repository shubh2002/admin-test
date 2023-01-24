using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class OrderItems
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public int Pid { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
    }
}
