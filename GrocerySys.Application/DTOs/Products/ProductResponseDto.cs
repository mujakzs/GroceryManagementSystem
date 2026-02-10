namespace GrocerySys.Application.DTOs.Products;

public class ProductResponseDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public int LowStockThreshold { get; set; }
}
