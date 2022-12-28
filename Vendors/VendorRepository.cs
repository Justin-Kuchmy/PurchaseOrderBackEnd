using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using System.Numerics;

namespace PurchaseOrderBackEnd.Vendors
{
    public class VendorRepository : IRepository<Vendors, int>
    {
        private readonly VendorAndProductsDBContext _db;
        public VendorRepository(VendorAndProductsDBContext db)
        {
            _db = db;

        }


        public async Task<bool> deleteOne(int id)
        {
            var vendor = await _db.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return false;
            }
            var result = _db.Vendors.Remove(vendor);
            if(result == null)
            {
                return false;
            }
            await Save();
            return true;
        }
        public async Task<Vendors?> addOne(Vendors vendorRequest)
        {
            var result = await _db.Vendors.AddAsync(vendorRequest);
            if (result == null)
            {
                return null;
            }
            await Save();
            return vendorRequest;

        }        
        public async Task<Vendors?> updateOne(int id, Vendors vendorRequest)
        {
            var vendorToChange = await _db.Vendors.FirstOrDefaultAsync(x => x.Vendor_Id == id);
   
            
            if (vendorToChange == null)
            {
                return null;
            }
            vendorToChange.City = vendorRequest.City;

            if(await Save() == 1)
                return vendorToChange;
            return null;
        }

        public async Task<int> Save()
        {

            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<List<Vendors>> findAll()
        {
            var vendors = await _db.Vendors.ToListAsync();
            _db.ChangeTracker.Clear();
            return vendors;
        }


    }
}
