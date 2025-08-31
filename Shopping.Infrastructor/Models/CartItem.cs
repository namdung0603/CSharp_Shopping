namespace Shopping.Infrastructure.Models {
    public class CartItem {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPriceItem { get; set; }
        public Cart Cart { get; set; }
    }
}
