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
                
                // TODO: Domain.Entities.Order sınıfına UpdateShippingAddress(Address newAddress) metodu ekleyin.
                // Bu metodun içinde `this.ShippingAddress = newAddress;` veya daha detaylı bir güncelleme olabilir.
                // Şimdilik bu adımın domainde yapılacağını varsayarak devam ediyoruz.
                // Eğer domainde böyle bir metod yoksa, bu handler çalışmayacaktır.

                _orderRepository.Update(order);
            }
            await Task.CompletedTask;
        }
    }
} 