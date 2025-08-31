using Shopping.Contract.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Infrastructure.Models {
    public class Order {
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        [Column(TypeName = "int")]
        public OrderStatus Status { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
        public Carrier Carrier { get; set; }
    }
}
