
using GrocerySys.Application.DTOs;
using GrocerySys.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrocerySys.API.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto dto)
    {
        var success = await _authService.LoginAsync(dto);
        if (!success)
            return Unauthorized("Invalid credentials.");

        return Ok("Login successful.");
    }
}
