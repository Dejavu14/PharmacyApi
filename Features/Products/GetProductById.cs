using Microsoft.EntityFrameworkCore;
using PharmacyApi.Data;
using PharmacyApi.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace PharmacyApi.Features.Products;

public static class GetProductById
{
    public static async Task<IResult> Handle(AppDbContext db, IMapper mapper, int id)
    {
        var productDto = await db.Products
            .Where(p => p.Id == id)
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Form)
            .Include(p => p.Supplier)
            .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return productDto is null ? Results.NotFound() : Results.Ok(productDto);
    }
}