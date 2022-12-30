using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using PurchaseOrderBackEnd.Vendors;
using System.Linq;
using System.Numerics;


namespace PurchaseOrderBackEnd.Products
{
    public class ProductRepository : IRepository<Products, string>
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

 
        public async Task<Products?> addOne(Products ProductRequest)
        {
            var result = await _db.Products.AddAsync(ProductRequest);
            if (result == null)
            {
                return null;
            }
            await Save();
            return ProductRequest;

        }
        public async Task<Products?> updateOne(string id, Products ProductRequest)
        {

           var productToChange = await _db.Products.FirstOrDefaultAsync(x => x.products_Id == id);
            if (productToChange == null)
            {
                return null;
            }
           productToChange.name = ProductRequest.name;
           productToChange.costprice = ProductRequest.costprice;
           productToChange.msrp = ProductRequest.msrp;
           productToChange.rop = ProductRequest.rop;
           productToChange.eoq = ProductRequest.eoq;
           productToChange.qoh = ProductRequest.qoh;
           productToChange.qoo = ProductRequest.qoo;
            if (await Save() == 1)
                return productToChange;
            return null;
        }

        public async Task<int> Save()
        {

            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<List<Products>> findAll()
        {
            throw new NotImplementedException();
        }

        public DbSet<Products> findAllFromQuery()
        {
            var Products = _db.Products;
            return Products;
        }

        public Task<List<Products>> findAllByVendor(int id)
        {
            //var _Products = await _db.Products.ToListAsync();
            var ProductsByVendor = _db.Products.Where(p => p.vendorid == id);
            return Task.FromResult(ProductsByVendor.ToList());
        }

        public async Task<Products?> getById(string id)
        {
            var prod = _db.Products.Where(p => p.products_Id == id);
            if (prod.FirstOrDefault() == null)
            {
                return null;
            }
            return prod.FirstOrDefault();
        }

    }
}
