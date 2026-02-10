
namespace GrocerySys.Domain.Entities;

public class Product
{
    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public decimal CostPrice { get; private set; }
    public decimal SellingPrice { get; private set; }
    public string? Barcode { get; private set; }
    public int LowStockThreshold { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Product() { } // EF Core requires a parameterless constructor  - EF Core needs this to create objects when loading from the database.

    public Product(string name, Guid categoryId, decimal costPrice, decimal sellingPrice, string? barcode, int lowStockThreshold)
    {
        ProductId = Guid.NewGuid();
        CategoryId = categoryId;
        CostPrice = costPrice;
        SellingPrice = sellingPrice;
        Barcode = barcode;
        LowStockThreshold = lowStockThreshold;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string name, decimal costPrice, decimal sellingPrice, int lowStockThreshold)
    {
        Name = name;
        CostPrice = costPrice;
        SellingPrice = sellingPrice;
        LowStockThreshold = lowStockThreshold;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}


// DOMAIN ENTITY - represents a business concept and protects its own rules.

/* public decimal SellingPrice { get; private set; }
This means:
  Values cannot be changed freely
   Changes must go through methods
    ✔ Prevents invalid state
    ✔ Enforces business rules
    ✔ Supports encapsulation */

/*
 * This structure follows:
    ✔ Encapsulation
    ✔ Domain-Driven Design (DDD)
    ✔ Clean Architecture
    ✔ Rich domain model
 */