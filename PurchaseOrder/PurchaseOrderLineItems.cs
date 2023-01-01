using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public class PurchaseOrderLineItems
    {
       public long LineItem_Id { get; set; }
       public long PurchaseOrdersid { get; set; }
       public string? productid { get; set; }
       public int qty { get; set; }
       public double price { get; set; }
    }
}