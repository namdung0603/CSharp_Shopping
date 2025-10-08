using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Models {
    public class Product {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public required string ProductName { get; set; }
        [Required]
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<ProductImage>? Images { get; set; }
        [Required]
        public required string Supplier { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<CartItem> CartItem { get; set; }
        public List<Category>? Categories { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
