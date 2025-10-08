using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class Category {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public required string CatagoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
