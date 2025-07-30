namespace PharmacyApi.Dtos;

public class ProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public string CategoryName { get; set; } = string.Empty;
    public string UnitName { get; set; } = string.Empty;
    public string FormName { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
}
