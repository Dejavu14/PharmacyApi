using AutoMapper;
using Microsoft.AspNetCore.Builder;
using PharmacyApi.Data;
using PharmacyApi.Dtos;

namespace PharmacyApi.Features.Products;

public static class ProductRoutes
{
    public static void MapProductRoutes(WebApplication app)
    {
        var group = app.MapGroup("/api/products").WithTags("Products");

        // GET all products
        group.MapGet("/", async (AppDbContext db, IMapper mapper) =>
        {
            return await GetProducts.Handle(db, mapper);
        });

        // GET product by ID
        group.MapGet("/{id:int}", async (AppDbContext db, IMapper mapper, int id) =>
        {
            return await GetProductById.Handle(db, mapper, id);
        });

        // POST create product
        group.MapPost("/", async (AppDbContext db, IMapper mapper, CreateProductDto dto) =>
        {
            return await CreateProduct.Handle(db, mapper, dto);
        });

        // PUT update product
        group.MapPut("/{id:int}", async (AppDbContext db, IMapper mapper, int id, UpdateProductDto dto) =>
        {
            return await UpdateProduct.Handle(db, mapper, id, dto);
        });

        // DELETE product
        group.MapDelete("/{id:int}", async (AppDbContext db, int id) =>
        {
            return await DeleteProduct.Handle(db, id);
        });
    }
}
