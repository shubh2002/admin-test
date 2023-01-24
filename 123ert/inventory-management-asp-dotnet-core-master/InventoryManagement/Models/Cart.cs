using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Cart
    {
        public long Id { get; set; }
        public string CartId { get; set; }
        public int Pid { get; set; }
        public int Quantity { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? OfferId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsSelected { get; set; }
        public string Pin { get; set; }

        public virtual Product P { get; set; }
    }
}
