using System;

namespace InventoryManagement.Models
{
    public class Faq
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public bool? IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
