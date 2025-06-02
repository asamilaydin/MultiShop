using MediatR;
using MultiShop.Order.Application.Dtos;
using System.Collections.Generic;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string UserId { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public List<CreateOrderDetailDto> OrderItems { get; set; }

        public CreateOrderCommand()
        {
            OrderItems = new List<CreateOrderDetailDto>();
        }
    }

    public class CreateOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
} 