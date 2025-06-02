using AutoMapper;
using MultiShop.Order.Application.Dtos;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.OrderFeatures.Queries.GetOrderById
{
    public class GetOrderByIdMapper : Profile
    {
        public GetOrderByIdMapper()
        {
            CreateMap<Domain.Entities.Order, GetOrderByIdQueryResult>();
            CreateMap<Domain.Entities.Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Address, AddressDto>();
        }
    }
} 