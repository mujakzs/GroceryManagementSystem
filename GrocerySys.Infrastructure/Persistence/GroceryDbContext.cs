

using GrocerySys.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrocerySys.Infrastructure.Persistence;

public class GroceryDbContext : DbContext
{
    public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
}


/*
 *  Final Rule to Remember (Very Important)
   -> DbContext knows about Domain Entities
   -> Domain Entities do NOT know about DbContext

SOLID PRINCIPLE APPLIED

| Principle             | How                                      |
| --------------------- | ---------------------------------------- |
| Single Responsibility | DbContext only maps entities             |
| Open/Closed           | You can add DbSets without breaking code |
| Dependency Inversion  | Higher layers don’t know EF exists       |

*/
