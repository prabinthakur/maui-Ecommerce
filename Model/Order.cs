using System;
using System.Collections.Generic;

namespace Second.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Number { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateOnly Date { get; set; }
    }
}
