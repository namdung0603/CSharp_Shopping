using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class Carrier {
        [Key]
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public ICollection<CarrierMethod> CarrierMethods { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
