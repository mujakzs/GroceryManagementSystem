

using GrocerySys.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrocerySys.Infrastructure.Persistence;

public class GroceryDbContext : DbContext
{
    public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
