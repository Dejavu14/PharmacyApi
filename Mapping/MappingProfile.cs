using AutoMapper;
using PharmacyApi.Models;
using PharmacyApi.Dtos;

namespace PharmacyApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping dari Product ke ProductDto (untuk tampilkan data)
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
            .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));

        // Mapping dari input DTO ke model (untuk create dan update)
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, UpdateProductDto>();
    }
}
