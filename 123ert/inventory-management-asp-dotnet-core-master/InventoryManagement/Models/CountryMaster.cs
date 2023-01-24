using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            Address = new HashSet<Address>();
            StateMaster = new HashSet<StateMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<StateMaster> StateMaster { get; set; }
    }
}
