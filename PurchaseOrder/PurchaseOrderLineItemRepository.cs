using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Interfaces;
using PurchaseOrderBackEnd.PurchaseOrders;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrderLineItemRepository
    {
        private readonly VendorAndProductsDBContext _db;
        public PurchaseOrderLineItemRepository(VendorAndProductsDBContext db)
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
            if (result == null)
            {
                return false;
            }
            await Save();
            return true;
        }
        public async Task<PurchaseOrderLineItems> addOne(PurchaseOrderLineItems PurchaseOrderRequest)
        {
            var poResult = await _db.PurchaseOrderLineItems.AddAsync(PurchaseOrderRequest);
            if (poResult == null)
            {
                return null;
            }
            await Save();
            return PurchaseOrderRequest;

        }
        public Task<bool> updateOne(int id, PurchaseOrders PurchaseOrderRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save()
        {

            var result = await _db.SaveChangesAsync();
            return result;
        }



    }
}
