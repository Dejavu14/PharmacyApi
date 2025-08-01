using MediatR;
using PharmacyApi.Data;
using PharmacyApi.Dtos;
using PharmacyApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public record CreateProductCommand(CreateProductDto Dto) : IRequest<ProductDto>;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public CreateProductHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Dto);

        _db.Products.Add(product);
        await _db.SaveChangesAsync(cancellationToken);

        var result = await _db.Products
            .Include(p => p.Category)
            .Include(p => p.Unit)
            .Include(p => p.Form)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == product.Id, cancellationToken);

        return _mapper.Map<ProductDto>(result!);
    }
}
