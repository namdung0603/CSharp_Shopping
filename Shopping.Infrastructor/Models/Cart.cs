using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class Cart {
        [Key]
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
