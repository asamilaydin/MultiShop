using MediatR;
using System;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public string NewStatus { get; set; }
    }
} 