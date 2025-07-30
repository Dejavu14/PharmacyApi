using PharmacyApi.Data;

namespace PharmacyApi.Features.Products;

public static class DeleteProduct
{
    public static async Task<IResult> Handle(AppDbContext db, int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product is null) return Results.NotFound();

        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
}