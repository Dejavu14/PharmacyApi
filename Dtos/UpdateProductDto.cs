using System.ComponentModel.DataAnnotations;

namespace PharmacyApi.Dtos;

public class UpdateProductDto
{
    [Required(ErrorMessage = "Product name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Price must be >= 0.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock must be >= 0.")]
    public int Stock { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int UnitId { get; set; }

    [Required]
    public int FormId { get; set; }

    [Required]
    public int SupplierId { get; set; }
}
