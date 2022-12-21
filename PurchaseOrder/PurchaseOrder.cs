using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using PurchaseOrderBackEnd.PurchaseOrderLineItems;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrder
    {
        public long Id { get; set; }
        public long vendorid { get; set; }
        public long amount { get; set; } 
        public DateTime podate { get; set; }
        public List<PurchaseOrderLineItem> items = new();
    }
}