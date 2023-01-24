using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
            OrderStatuses = new HashSet<OrderStatus>();
        }
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public long? CouponId { get; set; }
        public decimal TotalMRP { get; set; }
        public decimal TotalSaving { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal DeliveryCharges { get; set; }
        public decimal? DeliveryDiscount { get; set; }
        public decimal? CouponDiscount { get; set; }
        public string PaymentMode { get; set; } = null!;
        public string PaymentId { get; set; } = null!;
        public int StoreId { get; set; }
        public string OrderId { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public string PaymentStatus { get; set; } = null!;
        public int Quantity { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }

        public virtual Address Address { get; set; }
        public virtual CouponMaster Coupon { get; set; }
        public virtual StoreMaster Store { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
