using Store.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ProductCategory

            modelBuilder.Entity<ProductCategory>()
    .HasKey(nameof(ProductCategory.Seq_Id), nameof(ProductCategory.Product_Category_Code));




            #endregion

            #region ProductType

            modelBuilder.Entity<ProductType>()
.HasKey(nameof(ProductType.Seq_Id), nameof(ProductType.Product_Type_Code));
            modelBuilder.Entity<ProductType>().HasOne<ProductCategory>(p => p.ProductCategory).WithMany(p => p.ProductTypes).HasForeignKey(p => p.Product_Category_Code).HasPrincipalKey(p => p.Product_Category_Code);

            #endregion

            #region Product




            modelBuilder.Entity<Product>()
.HasKey(nameof(Product.Seq_Id), nameof(Product.Product_Code));
            modelBuilder.Entity<Product>().HasOne<ProductType>(p => p.ProductType).WithMany(p => p.Products).HasForeignKey(p => p.Product_Type_Code).HasPrincipalKey(p => p.Product_Type_Code);

            #endregion

            base.OnModelCreating(modelBuilder);
        }


        #endregion
        #region Entities



        #region Guide
        public DbSet<ProductCategory> ProductCategories { get; set; }

        #endregion



        #endregion


    }

}
