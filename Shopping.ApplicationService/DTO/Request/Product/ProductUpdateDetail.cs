namespace Shopping.ApplicationService.DTO.Request.Product {
    public class ProductUpdateDetail {
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Supplier { get; set; }
        public List<int>? Categories { get; set; }
    }
}
