using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Drawing;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Vendors;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public abstract class PurchaseOrderPDFGenerator
    {
        public static MemoryStream generateReport(long poid,VendorRepository vendorRepository,ProductRepository productRepository,PurchaseOrderRepository purchaseorderRepository)
        {
            MemoryStream memory = new MemoryStream();

            string Example = "Example Content";
            byte[] byteInfo = Encoding.ASCII.GetBytes(Example);
            memory.Write(byteInfo, 0, byteInfo.Length);
            memory.Position = 0;

            return memory;
        }
    }

}