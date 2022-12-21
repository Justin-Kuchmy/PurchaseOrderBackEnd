using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using System.Numerics;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrder, int>
    {
        private readonly VendorAndProductsDBContext _db;
        public PurchaseOrderRepository(VendorAndProductsDBContext db)
        {
            _db = db;
        }


        public async Task<bool> deleteOne(int id)
        {
            var PurchaseOrder = await _db.PurchaseOrders.FindAsync(id);
            if (PurchaseOrder == null)
            {
                return false;
            }
            var result = _db.PurchaseOrders.Remove(PurchaseOrder);
            if(result == null)
            {
                return false;
            }
            await Save();
            return true;
        }
        public async Task<PurchaseOrder?> addOne(PurchaseOrder PurchaseOrderRequest)
        {
            var result = await _db.PurchaseOrders.AddAsync(PurchaseOrderRequest);
            if (result == null)
            {
                return null;
            }
            await Save();
            return PurchaseOrderRequest;

        }        
        public async Task<bool> updateOne(PurchaseOrder PurchaseOrderRequest)
        {
            var result = _db.PurchaseOrders.Update(PurchaseOrderRequest);
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

        public async Task<List<PurchaseOrder>> findAll()
        {
            var PurchaseOrders = await _db.PurchaseOrders.ToListAsync();
            return PurchaseOrders;
        }


    }
}
