using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductVarientMaster
    {
        public ProductVarientMaster()
        {
            ProductVarient = new HashSet<ProductVarient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductVarient> ProductVarient { get; set; }
    }
}
