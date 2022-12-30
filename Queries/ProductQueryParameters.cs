namespace PurchaseOrderBackEnd.Queries
{
    public class ProductQueryParameters : QueryParameters
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public string Products_id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
