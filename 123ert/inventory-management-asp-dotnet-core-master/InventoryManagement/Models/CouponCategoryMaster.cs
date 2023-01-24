using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class CouponCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
