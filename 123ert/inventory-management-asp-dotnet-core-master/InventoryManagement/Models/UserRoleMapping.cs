using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class UserRoleMapping
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
