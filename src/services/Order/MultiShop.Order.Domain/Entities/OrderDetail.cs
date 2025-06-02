using System;

namespace MultiShop.Order.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public decimal SubTotal => UnitPrice * Quantity;

        public OrderDetail(Guid orderId, Guid productId, string productName, decimal unitPrice, int quantity)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        
        private OrderDetail() {}
    }
} 