using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class QuestionAnswer
    {
        public long Id { get; set; }
        public int? Pid { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Attachment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsApproved { get; set; }
        public string Name { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
