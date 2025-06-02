using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult?>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResult?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                return null;
            }
            return _mapper.Map<GetOrderByIdQueryResult>(order);
        }
    }
} 