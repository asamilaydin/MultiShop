using AutoMapper;
using MultiShop.Order.Application.Dtos;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.OrderFeatures.Commands.UpdateShippingAddress
{
    public class UpdateShippingAddressMapper : Profile
    {
        public UpdateShippingAddressMapper()
        {
            CreateMap<AddressDto, Address>();
        }
    }
} 