using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Vendors;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.PurchaseOrders;
using PurchaseOrderBackEnd.PurchaseOrderLineItems;

namespace PurchaseOrderBackEnd.Data
{
    public class VendorAndProductsDBContext : DbContext
    {
        public VendorAndProductsDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<Vendor>();
        //    dpk.HasKey(x => x.Id);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<Product>();
        //    dpk.HasKey(x => x.Id);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<PurchaseOrder>();
        //    dpk.HasKey(x => x.Id);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<PurchaseOrderLineItem>();
        //    dpk.HasKey(x => x.Id);
        //}

    }
}
