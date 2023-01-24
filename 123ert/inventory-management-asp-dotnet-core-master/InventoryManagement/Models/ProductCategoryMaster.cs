using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductCategoryMaster
    {
        public ProductCategoryMaster()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayImage { get; set; }
        public bool? IsActive { get; set; }
        public int? Order { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
