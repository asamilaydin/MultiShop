using AutoMapper;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class ProductDetailProfile : Profile
    {
        public ProductDetailProfile()
        {
            // Entity -> DTO
            CreateMap<ProductDetail, ProductDetailDto>();

            // DTO -> Entity
            CreateMap<CreateProductDetailDto, ProductDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateProductDetailDto, ProductDetail>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
} 