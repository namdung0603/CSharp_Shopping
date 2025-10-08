using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class CarrierMethod {
        [Key]
        public int Id { get; set; }
        public Carrier Carrier { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public double Price { get; set; }

    }
}
