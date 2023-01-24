using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class SupplierMaster
    {
        public SupplierMaster()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string InfoEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public bool? IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
