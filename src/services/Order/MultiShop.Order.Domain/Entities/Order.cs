using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiShop.Order.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime OrderDate { get; private set; }
        
        public Address ShippingAddress { get; private set; }

        private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
        public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();

        private Order() { }

        public static Order Create(string userId, Address shippingAddress)
        {            
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                ShippingAddress = shippingAddress,
                TotalPrice = 0
            };
            return order;
        }

        public void AddOrderDetail(Guid productId, string productName, decimal unitPrice, int quantity)
        {
            var existingItem = _orderDetails.FirstOrDefault(od => od.ProductId == productId);
            if (existingItem != null)
            {
            } 
            else
            {
                var orderDetail = new OrderDetail(this.Id, productId, productName, unitPrice, quantity);
                _orderDetails.Add(orderDetail);
            }
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = _orderDetails.Sum(od => od.SubTotal);
        }
    }
}