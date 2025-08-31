namespace Shopping.Infrastructure.Models {
    public class CarrierMethod {
        public int Id { get; set; }
        public Carrier Carrier { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public double Price { get; set; }

    }
}
