using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Vendors;

namespace PurchaseOrderBackEnd.Data
{
    public class VendorAndProductsDBContext : DbContext
    {
        public VendorAndProductsDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        //public DbSet<PurchaseOrder> vendors { get; set; }
        //public DbSet<Product> vendors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<Vendor>();
        //    dpk.HasKey(x => x.Id);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var dpk = modelBuilder.Entity<Vendor>();
        //    dpk.HasKey(x => x.Id);
        //}

    }
}
