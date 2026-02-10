using GrocerySys.Domain.Entities;

namespace GrocerySys.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
}
















// INTERFACE - is a contract that defines what a class can do, without saying how it does it.
//              (THINK OF IT AS PROMISE).

/*
 MAIN PURPOSE:
 1. To separate what from how

        WHAT → application logic needs product data

        HOW → database logic (EF Core, SQL, etc.)

        Application layer cares about what, not how.


  2. To protect the Application layer

    without interface:
    ProductService → ProductRepository → EF Core → SQL Server

    with interface:
    ProductService → IProductRepository
                     ↑
               ProductRepository (EF Core)



  3. To follow SOLID (Dependency Inversion)
        ✅ SOLID
            Dependency Inversion: Application depends on abstraction 

        Meaning:
            High-level module (services)
            Low-level module (repositories)

 */


/* 

This interface says:

“Any class that claims to be a ProductRepository MUST be able to:
    - add a product
    - get a product by ID
    - get all products
    - update a product”

But it does NOT say:
    - how data is stored
    - whether it uses SQL Server
    - whether it uses EF Core
*/