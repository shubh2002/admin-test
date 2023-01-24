using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class OrderStatus
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string DeliveryStatus { get; set; } = null!;
        public DateTime Date { get; set; }
        public long UpdatedBy { get; set; }
        public virtual Order Order { get; set; }
    }
}
