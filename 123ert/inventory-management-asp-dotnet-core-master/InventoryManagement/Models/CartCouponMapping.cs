using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class CartCouponMapping
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CouponId { get; set; }
    }
}
