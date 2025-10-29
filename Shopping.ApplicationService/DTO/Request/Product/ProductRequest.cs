namespace Shopping.ApplicationService.DTO.Request.Product {
    public class ProductRequest {
        public required string ProductName { get; set; }
        public required double Price { get; set; }
        public required int Quantity { get; set; }
        public required string Supplier { get; set; }
        public required List<string> Categories { get; set; }
    }
}
