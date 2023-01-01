using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Vendors;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.PurchaseOrders;
using PurchaseOrderBackEnd.Migrations;

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
        public DbSet<PurchaseOrderLineItems> PurchaseOrderLineItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasSequence("Id_Sequence");
        //    modelBuilder.Entity<Vendors.Vendors>()
        //        .Property(x => x.Vendor_Id)
        //        .HasDefaultValue("NEXT VALUE FOR dbo.Id_Sequence");
        //}

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence("Id_Sequence");
            //    modelBuilder.Entity<Vendors.Vendors>()
            //        .Property(x => x.Vendor_Id)
            //        .HasDefaultValue("NEXT VALUE FOR dbo.Id_Sequence");

            var vend = modelBuilder.Entity<Vendors.Vendors>();
            vend.HasKey(x => x.table_key);
            //vend.HasNoKey();

            base.OnModelCreating(modelBuilder);
            var prod = modelBuilder.Entity<Products.Products>();
            prod.HasNoKey();



            var pOrder = modelBuilder.Entity<PurchaseOrders.PurchaseOrders>();
            pOrder.HasNoKey();

            var pOrderItem = modelBuilder.Entity<PurchaseOrderLineItems>();
            pOrderItem.HasNoKey();
        }
    }
}
