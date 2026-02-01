using GrocerySys.Domain.Entities;

namespace GrocerySys.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}
