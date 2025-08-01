using MediatR;
using Microsoft.AspNetCore.Builder;
using PharmacyApi.Dtos;

namespace PharmacyApi.Features.Products;

public static class ProductRoutes
{
    public static void MapProductRoutes(WebApplication app)
    {
        var group = app.MapGroup("/api/products")
            .WithTags("Products")
            .RequireAuthorization(); 

        // GET all products
        group.MapGet("/", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());
            return Results.Ok(result);
        });

        // GET product by ID
        group.MapGet("/{id:int}", async (ISender sender, int id) =>
        {
            var result = await sender.Send(new GetProductById(id));
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        // POST create product
        group.MapPost("/", async (ISender sender, CreateProductDto dto) =>
        {
            var result = await sender.Send(new CreateProductCommand(dto));
            return Results.Created($"/api/products/{result.Id}", result);
        });

        // PUT update product
        group.MapPut("/{id:int}", async (ISender sender, int id, UpdateProductDto dto) =>
        {
            var success = await sender.Send(new UpdateProductCommand(id, dto));
            return success ? Results.NoContent() : Results.NotFound();
        });

        // DELETE product
        group.MapDelete("/{id:int}", async (ISender sender, int id) =>
        {
            var success = await sender.Send(new DeleteProductCommand(id));
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}
