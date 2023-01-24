using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Address
    {
        public Address()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public long UserId { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressTypeId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual CountryMaster Country { get; set; }
        public virtual StateMaster State { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
