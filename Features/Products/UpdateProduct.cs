using MediatR;
using PharmacyApi.Data;
using PharmacyApi.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApi.Features.Products;

public record UpdateProductCommand(int Id, UpdateProductDto Dto) : IRequest<bool>;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public UpdateProductHandler(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null) return false;

        _mapper.Map(request.Dto, product);

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
