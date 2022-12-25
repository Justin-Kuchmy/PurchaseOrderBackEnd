using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Data;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrderDAO
    {

        public async Task<PurchaseOrders> create(PurchaseOrders clientRequest, ProductRepository prodRepo, PurchaseOrderLineItemRepository poLineItemRepo, VendorAndProductsDBContext _db)
        {
            //int size = clientRequest.items.Length;
            PurchaseOrders realPurchaseOrder = new PurchaseOrders();
            realPurchaseOrder.items = new List<PurchaseOrderLineItems>();
            realPurchaseOrder.podate = DateTime.Now;
            realPurchaseOrder.vendorid = clientRequest.vendorid;
            realPurchaseOrder.amount = clientRequest.amount;
            foreach (PurchaseOrderLineItems item in clientRequest.items)
            {
                PurchaseOrderLineItems realItem = new PurchaseOrderLineItems();
                realItem.PurchaseOrdersid = realPurchaseOrder.id;
                realItem.productid = item.productid;
                realItem.qty = item.qty;
                realItem.price = (long)Math.Floor((decimal)item.price);


                var prod = await prodRepo.getById(item.productid);
                if (prod != null)
                {
                    prod.qoo = prod.qoo + item.qty;
                    prod.costprice = item.price;
                    prod.eoq = prod.eoq + item.qty;
                }
                await poLineItemRepo.addOne(realItem);
                _db.SaveChanges();
                //_db.PurchaseOrderLineItems.Add(realItem);
                //realPurchaseOrder.items[index] = realItem;
                //realPurchaseOrder.items.Add(realItem);// = realItem;
                //realPurchaseOrder.AddItem(realItem);
            }
            
            return realPurchaseOrder;

        }
        
    }
}