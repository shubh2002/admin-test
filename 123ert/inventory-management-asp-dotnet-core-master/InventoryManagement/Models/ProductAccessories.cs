using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductAccessories
    {
        public long Id { get; set; }
        public int Pid { get; set; }
        public int AccessoryId { get; set; }
    }
}
