using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class CouponMaster
    {
        public CouponMaster()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string ShortDescription { get; set; } = null!;
        public string LongDescription { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public decimal? FlatDiscount { get; set; }
        public bool? IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ApplicableCount { get; set; }
        public int? CouponCategoryId { get; set; }
        public decimal? MinimumCartAmount { get; set; }
        public bool? IsPrivate { get; set; }
        public int? Priority { get; set; }
        public decimal? MaxDiscount { get; set; }
        public string Pin { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
