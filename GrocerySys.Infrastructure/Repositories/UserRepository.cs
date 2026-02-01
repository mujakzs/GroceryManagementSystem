//UserRepository is a concrete repository that implements IUserRepository
//and uses Entity Framework Core to handle user-related database operations asynchronously.

//LINQ is a C# feature that allows querying data using strongly typed expressions, which Entity Framework translates into SQL for database execution.


using GrocerySys.Application.Interfaces;
using GrocerySys.Domain.Entities;
using GrocerySys.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace GrocerySys.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GroceryDbContext _context;
    public UserRepository(GroceryDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByUsernameAsync(string username)
    {
                                                                //Go to the Users table, find the first user whose Username matches the given username, and return it.If none exists, return null.
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username); //(u => u.Username == username) For each user u, check if u.Username equals the given username
                                                               //Find the first user whose username matches. If none exists, return null
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}

