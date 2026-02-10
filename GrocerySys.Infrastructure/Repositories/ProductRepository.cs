using GrocerySys.Application.DTOs.Products;
using GrocerySys.Application.Interfaces;
using GrocerySys.Domain.Entities;
using GrocerySys.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace GrocerySys.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly GroceryDbContext _dbContext;

    public ProductRepository(GroceryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products.Where(p => p.IsActive).ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }


}
