using System;
using System.Collections.Generic;

namespace MultiShop.Order.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }

        public OrderDto()
        {
            OrderDetails = new List<OrderDetailDto>();
        }
    }
} 