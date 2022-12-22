using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using System.Numerics;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrders, int>
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
        public async Task<PurchaseOrders?> addOne(PurchaseOrders PurchaseOrderRequest)
        {
            var poResult = await _db.PurchaseOrders.AddAsync(PurchaseOrderRequest);
            if (poResult == null)
            {
                return null;
            }
            foreach (var item in PurchaseOrderRequest.items)
            {
                var itemResult = _db.PurchaseOrderLineItems.AddAsync(item);
                if (itemResult == null)
                {
                    return null;
                }
            }
            await Save();
            return PurchaseOrderRequest;

        }        
        public async Task<bool> updateOne(PurchaseOrders PurchaseOrderRequest)
        {
            var result = _db.PurchaseOrders.Update(PurchaseOrderRequest);
            if (result == null)
            {
                return false;
            }
            await Save();
            return true;
        }

        public async Task<int> Save()
        {

            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<List<PurchaseOrders>> findAll()
        {
            var PurchaseOrders = await _db.PurchaseOrders.ToListAsync();
            return PurchaseOrders;
        }


    }
}
