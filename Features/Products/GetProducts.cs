using Microsoft.EntityFrameworkCore;
using PharmacyApi.Data;
using PharmacyApi.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace PharmacyApi.Features.Products;

public static class GetProducts
{
    public static async Task<IResult> Handle(AppDbContext db, IMapper mapper)
    {
        var productDtos = await db.Products
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Form)
            .Include(p => p.Supplier)
            .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Results.Ok(productDtos);
    }
}