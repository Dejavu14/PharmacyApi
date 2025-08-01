// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using PharmacyApi.Data;
// using PharmacyApi.Models;
// using PharmacyApi.Dtos;
// using AutoMapper;
// using Microsoft.AspNetCore.Authorization;

// namespace PharmacyApi.Controllers;

// [Authorize]
// [ApiController]
// [Route("api/[controller]")]
// public class ProductsController : ControllerBase
// {
//     private readonly AppDbContext _context;
//     private readonly IMapper _mapper;

//     public ProductsController(AppDbContext context, IMapper mapper)
//     {
//         _context = context;
//         _mapper = mapper;
//     }

//     // Get with DTO
//     [HttpGet("dto")]
//     public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductDtos()
//     {
//         var products = await _context.Products
//             .Include(p => p.Category)
//             .Include(p => p.Unit)
//             .Include(p => p.Form)
//             .Include(p => p.Supplier)
//             .ToListAsync();

//         var productDtos = _mapper.Map<List<ProductDto>>(products);
//         return Ok(productDtos);
//     }

//     // Get by ID with DTO
//     [HttpGet("dto/{id}")]
//     public async Task<ActionResult<ProductDto>> GetProductDto(int id)
//     {
//         var product = await _context.Products
//             .Include(p => p.Category)
//             .Include(p => p.Unit)
//             .Include(p => p.Form)
//             .Include(p => p.Supplier)
//             .FirstOrDefaultAsync(p => p.Id == id);

//         if (product == null) return NotFound();

//         var productDto = _mapper.Map<ProductDto>(product);
//         return Ok(productDto);
//     }

//     // POST: Create product with validation
//     [HttpPost]
//     public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);

//         var product = _mapper.Map<Product>(dto);
//         _context.Products.Add(product);
//         await _context.SaveChangesAsync();

//         var result = _mapper.Map<ProductDto>(product);
//         return CreatedAtAction(nameof(GetProductDto), new { id = product.Id }, result);
//     }

//     // PUT: Update product
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);

//         var product = await _context.Products.FindAsync(id);
//         if (product == null) return NotFound();

//         _mapper.Map(dto, product);
//         await _context.SaveChangesAsync();

//         return NoContent();
//     }

//     // DELETE: Remove product
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteProduct(int id)
//     {
//         var product = await _context.Products.FindAsync(id);
//         if (product == null) return NotFound();

//         _context.Products.Remove(product);
//         await _context.SaveChangesAsync();

//         return NoContent();
//     }
// }
