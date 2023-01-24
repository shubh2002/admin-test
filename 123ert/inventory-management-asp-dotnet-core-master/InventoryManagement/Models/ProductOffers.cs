using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductOffers
    {
        public long Id { get; set; }
        public int Pid { get; set; }
        public long OfferId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product P { get; set; }
    }
}
