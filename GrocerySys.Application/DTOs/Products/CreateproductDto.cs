namespace GrocerySys.Application.DTOs.Products;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public string? Barcode { get; set; }
    public int LowStockThreshold { get; set; }
}
