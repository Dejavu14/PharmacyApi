using MediatR;
using PharmacyApi.Dtos;
using PharmacyApi.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public record GetProductById(int Id) : IRequest<ProductDto?>;

public class GetProductByIdHandler : IRequestHandler<GetProductById, ProductDto?>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        var product = await _db.Products
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Form)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        return product is null ? null : _mapper.Map<ProductDto>(product);
    }
}
