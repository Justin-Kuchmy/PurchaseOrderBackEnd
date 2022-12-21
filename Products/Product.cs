using System.ComponentModel.DataAnnotations;

namespace PurchaseOrderBackEnd.Products
{
    public class Product
    {
        [Key]
        public string Id { get; set; } = "";
        public int vendorid { get; set; }
        public string? name { get; set; }
        public long costprice { get; set; }
        public long msrp { get; set; }
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