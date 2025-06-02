using AutoMapper;
using MultiShop.Order.Application.Dtos;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderMapper : Profile
    {
        public CreateOrderMapper()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();
        }
    }
} 