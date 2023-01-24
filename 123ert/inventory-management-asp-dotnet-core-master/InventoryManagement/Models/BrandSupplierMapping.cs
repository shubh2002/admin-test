using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class BrandSupplierMapping
    {
        public long Id { get; set; }
        public int BrandId { get; set; }
        public int SuppliedId { get; set; }
    }
}
