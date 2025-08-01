using MediatR;
using PharmacyApi.Dtos;
using PharmacyApi.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public record GetProductsQuery() : IRequest<IEnumerable<ProductDto>>;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public GetProductsHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _db.Products
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Form)
            .Include(p => p.Supplier)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
