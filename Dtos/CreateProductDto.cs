using System.ComponentModel.DataAnnotations;

namespace PharmacyApi.Dtos;

public class CreateProductDto
{
    [Required(ErrorMessage = "Product name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than or equal to 0.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Unit is required.")]
    public int UnitId { get; set; }

    [Required(ErrorMessage = "Form is required.")]
    public int FormId { get; set; }

    [Required(ErrorMessage = "Supplier is required.")]
    public int SupplierId { get; set; }
}
