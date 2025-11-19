namespace Shopping.ApplicationService.DTO.Response {
    public class ProductResponse {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public ICollection<CategoryResponse> Categories { get; set; }
    }
}
