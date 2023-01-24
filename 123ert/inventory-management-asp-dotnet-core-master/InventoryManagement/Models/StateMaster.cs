using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class StateMaster
    {
        public StateMaster()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public bool? IsActive { get; set; }

        public virtual CountryMaster Country { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
