using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using PurchaseOrderBackEnd.Vendors;
using System.Numerics;


namespace PurchaseOrderBackEnd.Products
{
    public class ProductRepository : IRepository<Product, string>
    {
        private readonly VendorAndProductsDBContext _db;
        public ProductRepository(VendorAndProductsDBContext db)
        {
            _db = db;
        }

        public async Task<bool> deleteOne(string id)
        {
            var Product = await _db.Products.FindAsync(id);
            if (Product == null)
            {
                return false;
            }
            var result = _db.Products.Remove(Product);
            if (result == null)
            {
                return false;
            }
            await Save();
            return true;
        }

 
        public async Task<Product?> addOne(Product ProductRequest)
        {
            var result = await _db.Products.AddAsync(ProductRequest);
            if (result == null)
            {
                return null;
            }
            await Save();
            return ProductRequest;

        }
        public async Task<bool> updateOne(Product ProductRequest)
        {
            var result = _db.Products.Update(ProductRequest);
            if (result == null)
            {
                return false;
            }
            await Save();
            return true;
        }

        public Task Save()
        {

            var result = _db.SaveChangesAsync();
            return result;
        }

        public async Task<List<Product>> findAll()
        {
            var Products = await _db.Products.ToListAsync();
            return Products;
        }

        public async Task<List<Product>> findAllByVendor(int id)
        {
            //var _Products = await _db.Products.ToListAsync();
            var ProductsByVendor = _db.Products.Where(p => p.vendorid == id);
            return ProductsByVendor.ToList();
        }

    }
}
