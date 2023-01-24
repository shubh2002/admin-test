using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductVarient
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductVarientId { get; set; }
        public string VarientName { get; set; }
        public int VarientTypeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Product ProductVarientNavigation { get; set; }
        public virtual ProductVarientMaster VarientType { get; set; }
    }
}
