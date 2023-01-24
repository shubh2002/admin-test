using System;

namespace InventoryManagement.Models
{
    public partial class UserStoreMapping
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int StoreId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
