using GrocerySys.Application.DTOs.Products;
using GrocerySys.Application.Interfaces;
using GrocerySys.Domain.Entities;

namespace GrocerySys.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            if (dto.SellingPrice < dto.CostPrice)
            { 
                throw new Exception("Selling price cannot be less than cost price.");
            }

            var product = new Product(
                dto.Name,
                dto.CategoryId,
                dto.CostPrice,
                dto.SellingPrice,
                dto.Barcode,
                dto.LowStockThreshold
            );

            await _productRepository.AddAsync(product);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            //Mapping Entity -> Response DTO
            return products.Select(p => new ProductResponseDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                SellingPrice = p.SellingPrice,
                LowStockThreshold = p.LowStockThreshold
            }).ToList();
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            product.Update(
                dto.Name,
                dto.CostPrice,
                dto.SellingPrice,
                dto.LowStockThreshold
            );

            await _productRepository.UpdateAsync(product);
        }
    }
}




/* 
    Dependency Injection + Abstraction 

    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    What’s happening here

        - ProductService depends on IProductRepository (interface)
        - NOT on ProductRepository (concrete class)

    This means:

        - High-level module → depends on abstraction
        - Low-level module → implements abstraction

    This is the backbone of Clean Architecture.

 */

/* 
    Where SOLID principles are applied

      S — Single Responsibility Principle

            ProductService → business logic only
            ProductRepository → data access only
            DTOs → data transfer only

      O — Open/Closed Principle

            You can add new rules (e.g. discount logic)
            Without modifying repository code

      L — Liskov Substitution Principle

            Any implementation of IProductRepository works
            FakeRepo, SQLRepo, InMemoryRepo

      I — Interface Segregation Principle

            Repository interface is focused
            No unused methods forced

      D — Dependency Inversion Principle

            High-level (ProductService)
            Depends on abstraction (IProductRepository)
            NOT concrete DB implementation
 */