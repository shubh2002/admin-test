using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Review
    {
        public long Id { get; set; }
        public int FeedbackTypeId { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public long UserId { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Rating { get; set; }
    }
}
