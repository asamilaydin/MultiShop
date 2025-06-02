using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, List<GetOrdersByUserIdQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrdersByUserIdQueryResult>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.FindAsync(o => o.UserId == request.UserId);
            return _mapper.Map<List<GetOrdersByUserIdQueryResult>>(orders);
        }
    }
}
