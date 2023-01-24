using System;
using InventoryManagement.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InventoryManagement.Models;

namespace InventoryManagement.Models
{
    public partial class yournotebookContext : DbContext
    {
        public yournotebookContext()
        {
        }

        public yournotebookContext(DbContextOptions<yournotebookContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CategoryDto> CategoryDto { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressTypeMaster> AddressTypeMaster { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BrandMaster> BrandMaster { get; set; }
        public virtual DbSet<BrandSupplierMapping> BrandSupplierMapping { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartCouponMapping> CartCouponMapping { get; set; }
        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<CouponCategoryMaster> CouponCategoryMaster { get; set; }
        public virtual DbSet<CouponMaster> CouponMaster { get; set; }
        public virtual DbSet<FeedbackTypeMaster> FeedbackTypeMaster { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<OtpVerification> OtpVerification { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAccessories> ProductAccessories { get; set; }
        public virtual DbSet<ProductAka> ProductAka { get; set; }
        public virtual DbSet<ProductCategoryMaster> ProductCategoryMaster { get; set; }
        public virtual DbSet<ProductGallery> ProductGallery { get; set; }
        public virtual DbSet<ProductInventory> ProductInventory { get; set; }
        public virtual DbSet<ProductMetadata> ProductMetadata { get; set; }
        public virtual DbSet<ProductOffers> ProductOffers { get; set; }
        public virtual DbSet<ProductServices> ProductServices { get; set; }
        public virtual DbSet<ProductVarient> ProductVarient { get; set; }
        public virtual DbSet<ProductVarientMaster> ProductVarientMaster { get; set; }
        public virtual DbSet<PromotionBannerMaster> PromotionBannerMaster { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<StateMaster> StateMaster { get; set; }
        public virtual DbSet<StoreMaster> StoreMaster { get; set; }
        public virtual DbSet<SupplierMaster> SupplierMaster { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMapping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=yournotebook;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(11);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Country_Master");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_State_Master");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_AspNetUsers");
            });

            modelBuilder.Entity<AddressTypeMaster>(entity =>
            {
                entity.ToTable("AddressType_Master");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryPin)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.ProfilePictureUrl).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BrandMaster>(entity =>
            {
                entity.ToTable("Brand_Master");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InfoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription).HasMaxLength(500);

                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<BrandSupplierMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SuppliedId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Pin)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Product");
            });

            modelBuilder.Entity<CartCouponMapping>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UC_CartId")
                    .IsUnique();
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.ToTable("Country_Master");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CouponCategoryMaster>(entity =>
            {
                entity.ToTable("CouponCategory_Master");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CouponMaster>(entity =>
            {
                entity.ToTable("Coupon_Master");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Discount);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FlatDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LongDescription).HasMaxLength(500);

                entity.Property(e => e.MaxDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinimumCartAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FeedbackTypeMaster>(entity =>
            {
                entity.ToTable("FeedbackType_Master");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

               

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

             

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK_Order_Coupon_Master");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Store_Master");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_AspNetUsers");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OtpVerification>(entity =>
            {
                entity.Property(e => e.Otp)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ValidUpto).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Cid)
                    .HasColumnName("CID")
                    .HasComment("Category Id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountEnd).HasColumnType("datetime");

                entity.Property(e => e.DiscountStart).HasColumnType("datetime");

                entity.Property(e => e.DisplayUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MaximumBuyingDuration).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MonetizationFactor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShortDescription).HasMaxLength(500);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory_Master");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Product_Product");
            });

            modelBuilder.Entity<ProductAccessories>(entity =>
            {
                entity.Property(e => e.Pid).HasColumnName("PID");
            });

            modelBuilder.Entity<ProductAka>(entity =>
            {
                entity.ToTable("ProductAKA");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductCategoryMaster>(entity =>
            {
                entity.ToTable("ProductCategory_Master");

                entity.Property(e => e.DisplayImage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductGallery>(entity =>
            {
                entity.Property(e => e.DisplayUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.ProductGallery)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_ProductGallery_Product");
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pid).HasColumnName("PID");
            });

            modelBuilder.Entity<ProductMetadata>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMetadata)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMetadata_Product");
            });

            modelBuilder.Entity<ProductOffers>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.ProductOffers)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOffers_Product");
            });

            modelBuilder.Entity<ProductServices>(entity =>
            {
                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ReplaceDescription).HasMaxLength(500);

                entity.Property(e => e.ReturnDescription).HasMaxLength(500);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.ProductServices)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductServices_Product");
            });

            modelBuilder.Entity<ProductVarient>(entity =>
            {
                entity.Property(e => e.VarientName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVarientProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ProductVarientNavigation)
                    .WithMany(p => p.ProductVarientProductVarientNavigation)
                    .HasForeignKey(d => d.ProductVarientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VarientType)
                    .WithMany(p => p.ProductVarient)
                    .HasForeignKey(d => d.VarientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductVarient_ProductVarient_Master");
            });

            modelBuilder.Entity<ProductVarientMaster>(entity =>
            {
                entity.ToTable("ProductVarient_Master");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PromotionBannerMaster>(entity =>
            {
                entity.ToTable("PromotionBanner_Master");

                entity.Property(e => e.DisplayImage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.Property(e => e.Answer).HasMaxLength(500);

                entity.Property(e => e.Attachment).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Question).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.ToTable("Role_Master");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.ToTable("State_Master");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateMaster)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<StoreMaster>(entity =>
            {
                entity.ToTable("Store_Master");

                entity.Property(e => e.DeliveryCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FreeDeliveryMinCartValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Pin2)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierMaster>(entity =>
            {
                entity.ToTable("Supplier_Master");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InfoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(150);
            });
            modelBuilder.Entity<ProductDetails>().HasKey(x=>x.Id);
            modelBuilder.Entity<UserStoreMapping>().HasKey(x => x.Id);
            modelBuilder.Entity<CategoryDto>().HasKey(x => x.Id);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<InventoryManagement.Models.Faq> Faq { get; set; }
    }
}
