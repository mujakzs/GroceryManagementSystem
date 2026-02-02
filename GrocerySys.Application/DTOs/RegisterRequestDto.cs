
using System.ComponentModel.DataAnnotations;

namespace GrocerySys.Application.DTOs;

public class RegisterRequestDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "Cashier";
}
