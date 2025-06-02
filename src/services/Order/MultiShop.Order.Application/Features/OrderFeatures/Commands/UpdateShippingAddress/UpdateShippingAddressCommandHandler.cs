using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateShippingAddress
{
    public class UpdateShippingAddressCommandHandler : IRequestHandler<UpdateShippingAddressCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateShippingAddressCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order != null)
            {
                var newAddressEntity = _mapper.Map<Address>(request.NewShippingAddress);
                _orderRepository.Update(order);
            }
            await Task.CompletedTask;
        }
    }
} 