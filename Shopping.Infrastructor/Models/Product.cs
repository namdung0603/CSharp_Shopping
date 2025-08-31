using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Models {
    public class Product {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public required string ProductName { get; set; }
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage>? Images { get; set; }
        public required string Supplier { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CartItem CartItem { get; set; }
        public List<Category>? Categories { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
