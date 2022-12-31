using Microsoft.AspNetCore.Mvc;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Vendors;
using System.Net.Http.Headers;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderPDFController : Controller
    {
        private readonly VendorRepository _vendorRepository;
        private readonly PurchaseOrderRepository _PurchaseOrderRepository;
        private readonly ProductRepository _ProductRepository;

        public PurchaseOrderPDFController(VendorRepository vendorRepository, PurchaseOrderRepository purchaseOrderRepository, ProductRepository productRepository)
        {
            this._vendorRepository = vendorRepository;
            _ProductRepository = productRepository;
            _PurchaseOrderRepository = purchaseOrderRepository;
        }
        [HttpGet]
        [Route("/api/PurchaseOrdersPDF")]
        public FileStreamResult streamPDF([FromQuery] PurchaseOrders request)
        {
            var poid = request.po_id;
            Stream fileStream = PurchaseOrderPDFGenerator.generateReport(poid, _vendorRepository, _ProductRepository, _PurchaseOrderRepository);

            using var message = new HttpRequestMessage();
            var headers = message.Headers;
            headers.Add("Content-Disposition", "inline; filename=purchaseorder.pdf");

            return new FileStreamResult(fileStream, "application/pdf");
        }
    }
}