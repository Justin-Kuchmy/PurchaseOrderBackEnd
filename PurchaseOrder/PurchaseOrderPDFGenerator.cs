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

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    public abstract class PurchaseOrderPDFGenerator
    {
        public static MemoryStream generateReport( string poid,VendorRepository vendorRepository,ProductRepository productRepository,PurchaseOrderRepository purchaseorderRepository)
        {

            return new MemoryStream();
        }
    }

}