using MediatR;
using MultiShop.Order.Application.Dtos;
using System;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateShippingAddress
{
    public class UpdateShippingAddressCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public AddressDto NewShippingAddress { get; set; }
    }
} 