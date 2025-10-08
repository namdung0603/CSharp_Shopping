using Shopping.Contract.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Infrastructure.Models {
    public class ShippingMethod {
        [Key]
        public int Id { get; set; }
        public MethodShip Method { get; set; }
        public ICollection<CarrierMethod> CarrierMethods { get; set; }
}
}
