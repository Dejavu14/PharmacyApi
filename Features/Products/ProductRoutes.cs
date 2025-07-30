using PharmacyApi.Data;
using AutoMapper;
using PharmacyApi.Dtos;

namespace PharmacyApi.Features.Products;

public static class ProductRoutes
{
    public static void MapProductRoutes(WebApplication app)
    {
        var group = app.MapGroup("/api/products");

        // GET (List)
        group.MapGet("/", (AppDbContext db, IMapper mapper) =>
            GetProducts.Handle(db, mapper));

        // GET (By ID)
        group.MapGet("/{id:int}", (AppDbContext db, IMapper mapper, int id) =>
            GetProductById.Handle(db, mapper, id));

        // POST (Create)
        group.MapPost("/", (AppDbContext db, IMapper mapper, CreateProductDto dto) =>
            CreateProduct.Handle(db, mapper, dto));

        // PUT (Update)
        group.MapPut("/{id:int}", (AppDbContext db, IMapper mapper, int id, UpdateProductDto dto) =>
            UpdateProduct.Handle(db, mapper, id, dto));

        // DELETE
        group.MapDelete("/{id:int}", (AppDbContext db, int id) =>
            DeleteProduct.Handle(db, id));
    }
}
