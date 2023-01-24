using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InventoryManagement.Authentication
{
    public class OtpLoginModel
    {
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile Number is not valid")]
        [DataMember(EmitDefaultValue = false)]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Otp is required")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Otp is not valid")]
        [DataMember(EmitDefaultValue = false)]
        public string Otp { get; set; } = default!;
    }
}
