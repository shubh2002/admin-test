using InventoryManagement.Models;

namespace InventoryManagement.Dto
{
    public class ProductVarientsDto: Product
    {
        public bool IsSelected { get; set; }
        public int ProductId { get; set; }
        public int VarientTypeId { get; set; }
    }
}
