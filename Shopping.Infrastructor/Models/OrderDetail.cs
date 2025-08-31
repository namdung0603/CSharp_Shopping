﻿namespace Shopping.Infrastructure.Models {
    public class OrderDetail {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
