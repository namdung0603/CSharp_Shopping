namespace Shopping.Infrastructure.Models {
    public class Carrier {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public List<CarrierMethod> CarrierMethods { get; set; }
        public Order Order { get; set; }
    }
}
