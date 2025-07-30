using PharmacyApi.Data;
using PharmacyApi.Dtos;
using PharmacyApi.Models;
using AutoMapper;

namespace PharmacyApi.Features.Products;

public static class CreateProduct
{
    public static async Task<IResult> Handle(AppDbContext db, IMapper mapper, CreateProductDto dto)
    {
        var product = mapper.Map<Product>(dto);

        db.Products.Add(product);
        await db.SaveChangesAsync();

        var result = mapper.Map<ProductDto>(product);
        return Results.Created($"/api/products/{product.Id}", result);
    }
}
