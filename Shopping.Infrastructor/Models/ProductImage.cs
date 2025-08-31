using Shopping.Contract.Enums;

namespace Shopping.Infrastructure.Models {
    public class ProductImage {
        public int Id { get; set; }
        public string Path { get; set; }
        public TypeImage Type { get; set; }

        public Product Product { get; set; }
    }
}
