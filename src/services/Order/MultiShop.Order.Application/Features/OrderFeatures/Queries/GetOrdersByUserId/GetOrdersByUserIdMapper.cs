using AutoMapper;
using MultiShop.Order.Application.Dtos;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdMapper : Profile
    {
        public GetOrdersByUserIdMapper()
        {
            CreateMap<Domain.Entities.Order, GetOrdersByUserIdQueryResult>();
            CreateMap<Domain.Entities.Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Address, AddressDto>();
        }
    }
} 