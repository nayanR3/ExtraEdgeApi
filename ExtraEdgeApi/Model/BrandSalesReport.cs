namespace ExtraEdgeApi.Model
{
    public class BrandSalesReport
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public int TotalSales { get; set; }
        public int TotalDiscounts { get; set; }
        public int TotalQuantitySold { get; set; }
    }
}
