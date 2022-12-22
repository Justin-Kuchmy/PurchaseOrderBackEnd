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
        public DbSet<Vendors.Vendors> Vendors { get; set; }
        public DbSet<Products.Products> Products { get; set; }
        public DbSet<PurchaseOrders.PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLineItems.PurchaseOrderLineItems> PurchaseOrderLineItems { get; set; }

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
