using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile Number is not valid")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
    }
}
