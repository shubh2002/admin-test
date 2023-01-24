using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class OtpVerification
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Otp { get; set; }
        public DateTime ValidUpto { get; set; }
    }
}
