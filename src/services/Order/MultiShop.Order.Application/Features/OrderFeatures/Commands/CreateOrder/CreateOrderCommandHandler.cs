using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shippingAddressEntity = _mapper.Map<Address>(request.ShippingAddress);
            var order = Domain.Entities.Order.Create(request.UserId, shippingAddressEntity);

            foreach (var itemDto in request.OrderItems)
            {
                order.AddOrderDetail(itemDto.ProductId, itemDto.ProductName, itemDto.UnitPrice, itemDto.Quantity);
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            
            return order.Id;
        }
    }
} 