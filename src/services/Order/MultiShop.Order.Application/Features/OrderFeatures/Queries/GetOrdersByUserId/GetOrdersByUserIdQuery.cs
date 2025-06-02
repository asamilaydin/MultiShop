using MediatR;
using MultiShop.Order.Application.Dtos;
using System;
using System.Collections.Generic;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<List<GetOrdersByUserIdQueryResult>>
    {
        public Guid UserId { get; set; }

        // Constructor removed as it's not strictly necessary for a simple query object
        // and can be set via property initializer. If a constructor is desired, it should accept Guid.
        // public GetOrdersByUserIdQuery(Guid userId) 
        // {
        //     UserId = userId;
        // }
    }
} 