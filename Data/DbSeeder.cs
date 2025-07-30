using Bogus;
using PharmacyApi.Models;

namespace PharmacyApi.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        // Pastikan database sudah ada
        context.Database.EnsureCreated();

        // Seed Categories
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Id = 1, Name = "Antibiotik" },
                new Category { Id = 2, Name = "Vitamin" },
                new Category { Id = 3, Name = "Analgesik" }
            );
        }

        // Seed Units
        if (!context.Units.Any())
        {
            context.Units.AddRange(
                new Unit { Id = 1, Name = "Tablet" },
                new Unit { Id = 2, Name = "Botol" },
                new Unit { Id = 3, Name = "Strip" }
            );
        }

        // Seed Forms
        if (!context.Forms.Any())
        {
            context.Forms.AddRange(
                new Form { Id = 1, Name = "Sirup" },
                new Form { Id = 2, Name = "Kapsul" },
                new Form { Id = 3, Name = "Salep" }
            );
        }

        // Seed Suppliers
        if (!context.Suppliers.Any())
        {
            context.Suppliers.AddRange(
                new Supplier { Id = 1, Name = "PT Kimia Farma", Contact = "021-555" },
                new Supplier { Id = 2, Name = "PT Indo Farma", Contact = "021-123" }
            );
        }

        context.SaveChanges();

        // Seed Products (pakai Bogus)
        if (!context.Products.Any())
        {
            var faker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Price, f => f.Random.Decimal(1000, 20000))
                .RuleFor(p => p.Stock, f => f.Random.Int(10, 200))
                .RuleFor(p => p.CategoryId, f => f.PickRandom(1, 2, 3))
                .RuleFor(p => p.UnitId, f => f.PickRandom(1, 2, 3))
                .RuleFor(p => p.FormId, f => f.PickRandom(1, 2, 3))
                .RuleFor(p => p.SupplierId, f => f.PickRandom(1, 2));

            var dummyProducts = faker.Generate(50);
            context.Products.AddRange(dummyProducts);
            context.SaveChanges();
        }
    }
}
