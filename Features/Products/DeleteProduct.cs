using MediatR;
using PharmacyApi.Data;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public record DeleteProductCommand(int Id) : IRequest<bool>;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _db;

    public DeleteProductHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null) return false;

        _db.Products.Remove(product);
        await _db.SaveChangesAsync(cancellationToken);

        return true;
    }
}
