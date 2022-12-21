using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PurchaseOrderBackEnd.PurchaseOrderLineItems
{
    public class PurchaseOrderLineItem
    {
       public long Id { get; set; }
       public long poid { get; set; }
       public string productid { get; set; }
       public int qty { get; set; }
       public long price { get; set; }
    }
}