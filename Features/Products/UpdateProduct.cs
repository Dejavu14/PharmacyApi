using PharmacyApi.Data;
using PharmacyApi.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public static class UpdateProduct
{
    public static async Task<IResult> Handle(AppDbContext db, IMapper mapper, int id, UpdateProductDto dto)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return Results.NotFound();

        mapper.Map(dto, product);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
}