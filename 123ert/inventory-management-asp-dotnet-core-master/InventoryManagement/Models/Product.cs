using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            ProductGallery = new HashSet<ProductGallery>();
            ProductMetadata = new HashSet<ProductMetadata>();
            ProductOffers = new HashSet<ProductOffers>();
            ProductServices = new HashSet<ProductServices>();
            ProductVarientProduct = new HashSet<ProductVarient>();
            ProductVarientProductVarientNavigation = new HashSet<ProductVarient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public string LongDescription { get; set; }
        public int? MaxBuyingQuantity { get; set; }
        public int? MinBuyingQuantity { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? SupplierId { get; set; }
        public decimal? MonetizationFactor { get; set; }
        public DateTime? DiscountStart { get; set; }
        public DateTime? DiscountEnd { get; set; }
        public int Cid { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? MaximumBuyingDuration { get; set; }
        public bool? IsActive { get; set; }
        public string DisplayUrl { get; set; }

        public virtual ProductCategoryMaster C { get; set; }
        public virtual SupplierMaster Supplier { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<ProductGallery> ProductGallery { get; set; }
        public virtual ICollection<ProductMetadata> ProductMetadata { get; set; }
        public virtual ICollection<ProductOffers> ProductOffers { get; set; }
        public virtual ICollection<ProductServices> ProductServices { get; set; }
        public virtual ICollection<ProductVarient> ProductVarientProduct { get; set; }
        public virtual ICollection<ProductVarient> ProductVarientProductVarientNavigation { get; set; }
    }
}
