using Shopping.Contract.Enums;

namespace Shopping.Infrastructure.Models {
    public class ShippingMethod {
        public int Id { get; set; }
        public MethodShip Method { get; set; }
        public List<CarrierMethod> MyProperty { get; set; }
    }
}
