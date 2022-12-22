using System.ComponentModel.DataAnnotations;

namespace PurchaseOrderBackEnd.Products
{
    public class Products
    {
        [Key]
        public string id { get; set; } = "";
        public int vendorid { get; set; }
        public string? name { get; set; }
        public double costprice { get; set; }
        public double msrp { get; set; }
        public int rop { get; set; }
        public int eoq { get; set; }
        public int qoh { get; set; }
        public int qoo { get; set; }
        public byte[]? qrcode { get; set; }
        public string? qrcodetxt { get; set; }
        public void setQrcode(byte[] generateQRCode)
        {
            if (generateQRCode.Length > 0)
            {
                this.qrcode = new byte[generateQRCode.Length];
                this.qrcode = generateQRCode;
            }
        }
    }
}