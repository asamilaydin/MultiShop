using MediatR;
using MultiShop.Order.Application.Dtos;
using System;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult?>
    {
        public Guid Id { get; set; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
} 