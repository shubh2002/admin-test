using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Dto
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public int? MaxBuyingQuantity { get; set; }
        public int? MinBuyingQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
        public DateTime? DiscountStart { get; set; }
        public DateTime? DiscountEnd { get; set; }
        public int SupplierId { get; set; }
        public int? Stock { get; set; }
        public string DisplayUrl { get; set; }
        public string? Store { get; set; }
        public decimal? MonetizationFactor { get; set; }
        public string SupplierName { get; set; }
        public bool? IsActive { get; set; }
    }
}
