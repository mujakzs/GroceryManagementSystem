
using GrocerySys.Application.DTOs;
using GrocerySys.Application.Interfaces;
using GrocerySys.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace GrocerySys.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterAsync(RegisterRequestDto dto)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(dto.Username);
        if (existingUser != null)
        {
            throw new Exception("Username already exists.");
        }
        var passwordHash = HashPassword(dto.Password);
        var user = new User(dto.Username, passwordHash, dto.Role);
        await _userRepository.AddAsync(user);
    }

    public async Task<bool> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        if (user == null || !user.IsActive)
        {
            return false;
        }
        var passwordHash = HashPassword(dto.Password);
        return user.PasswordHash == passwordHash;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
