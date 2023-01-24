using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class ProductServices
    {
        public long Id { get; set; }
        public int Pid { get; set; }
        public bool? IsReturnable { get; set; }
        public bool? IsReplacable { get; set; }
        public int? ReturnDuration { get; set; }
        public int? ReplaceDuration { get; set; }
        public string ReturnDescription { get; set; }
        public string ReplaceDescription { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public long CreatedDate { get; set; }
        public long? ModifiedDate { get; set; }

        public virtual Product P { get; set; }
    }
}
