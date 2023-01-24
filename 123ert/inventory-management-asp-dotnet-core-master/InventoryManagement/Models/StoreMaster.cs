using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class StoreMaster
    {
        public StoreMaster()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long AddressId { get; set; }
        public DateTime StartDate { get; set; }
        public bool? IsActive { get; set; }
        public decimal FreeDeliveryMinCartValue { get; set; }
        public decimal DeliveryCharges { get; set; }
        public string Pin { get; set; }
        public string Pin2 { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
