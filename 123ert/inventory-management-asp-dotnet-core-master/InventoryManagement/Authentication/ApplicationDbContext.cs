using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        CustomRole, Int64, CustomUserClaim, CustomUserRole, CustomUserLogin, CustomRoleClaim, CustomToken>// IdentityDbContext<ApplicationUser, CustomUserRole, Int64>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    public class CustomRole : IdentityRole<Int64>
    {
        public CustomRole()
        {

        }
        public CustomRole(string roleName) : base(roleName) { }
    }
    public class CustomUserClaim : IdentityUserClaim<Int64> { }
    public class CustomUserRole : IdentityUserRole<Int64> { }
    public class CustomUserLogin : IdentityUserLogin<Int64> { }
    public class CustomRoleClaim : IdentityRoleClaim<Int64> { }
    public class CustomToken : IdentityUserToken<Int64> { }
}
