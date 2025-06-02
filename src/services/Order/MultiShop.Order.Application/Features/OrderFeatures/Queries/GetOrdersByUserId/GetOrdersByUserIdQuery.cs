using MediatR;
using MultiShop.Order.Application.Dtos;
using System.Collections.Generic;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<List<GetOrdersByUserIdQueryResult>>
    {
        public string UserId { get; set; }

        public GetOrdersByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
} 