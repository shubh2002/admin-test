using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class PromotionBannerMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayImage { get; set; }
        public int Order { get; set; }
        public bool? IsActive { get; set; }
        public string Pin { get; set; }
    }
}
