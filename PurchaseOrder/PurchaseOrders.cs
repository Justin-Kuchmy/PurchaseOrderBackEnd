using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using PurchaseOrderBackEnd.PurchaseOrders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrders
    {
        public long po_id { get; set; }
        public long vendorid { get; set; }
        public double amount { get; set; } 
        public DateTime podate { get; set; }
        public List<PurchaseOrderLineItems> items { get; set; } = default!;

        //public void AddItem(PurchaseOrderLineItems.PurchaseOrderLineItems item)
        //{
        //    this.items.Add(item);
        //    return;
        //}

    }
}