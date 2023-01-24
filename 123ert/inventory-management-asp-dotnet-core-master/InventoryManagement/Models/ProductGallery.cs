using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductGallery
    {
        public long Id { get; set; }
        public int? Pid { get; set; }
        public string DisplayUrl { get; set; }
        public bool? IsActive { get; set; }
        public virtual Product P { get; set; }
        public int Order { get; set; }
    }
}
