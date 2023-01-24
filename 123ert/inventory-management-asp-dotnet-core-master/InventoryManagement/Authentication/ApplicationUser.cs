using Microsoft.AspNetCore.Identity;
using System;

namespace InventoryManagement.Authentication
{
    public class ApplicationUser: IdentityUser<Int64>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ProfilePictureUrl { get; set; } 
        public Int64? RefererId { get; set; } 
        public DateTime? DOB { get; set; }
        public bool? IsStudent { get; set; }
        public string? DeliveryPin { get; set; }
    }
}
