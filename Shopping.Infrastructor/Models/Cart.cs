namespace Shopping.Infrastructure.Models {
    public class Cart {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
