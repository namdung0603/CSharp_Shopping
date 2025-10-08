using Shopping.Contract.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class ProductImage {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public TypeImage Type { get; set; }

        public Product Product { get; set; }
    }
}
