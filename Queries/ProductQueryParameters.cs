namespace PurchaseOrderBackEnd.Queries
{
    public class ProductQueryParameters : QueryParameters
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
