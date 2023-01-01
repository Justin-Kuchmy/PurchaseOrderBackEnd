using Microsoft.AspNetCore.Mvc;
using PurchaseOrderBackEnd.Data;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.Vendors;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PurchaseOrderBackEnd.PurchaseOrders
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderPDFController : Controller
    {
        private const string V = "application/pdf";
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
        [Route("/api/PurchaseOrdersPDF/{id}")]
        public HttpResponseMessage streamPDF([FromBody] PurchaseOrders request, [FromRoute] long id)
        {
            var poid = id;
            MemoryStream fileStream = PurchaseOrderPDFGenerator.generateReport(poid, _vendorRepository, _ProductRepository, _PurchaseOrderRepository);

            //using var message = new HttpRequestMessage();
            using var message = new HttpResponseMessage();
            //using var message = new HttpContent();
            var test = message.Content;
            var headers = message.Headers;
            //headers.Add("content-disposition", "inline; filename=purchaseorder.pdf");
            //headers.Add("content-type", "application/json;charset=UTF-8");

            StringContent? content = new StringContent(fileStream.ToString());
            content.Headers.Expires = DateTime.Now.AddHours(4);
            content.Headers.ContentType.MediaType = V;


            //return fileStream;
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content.ToString()) };
            //return new FileStreamResult(fileStream, "application/pdf");
        }
    }
}