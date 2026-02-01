
using GrocerySys.API.Security;
using GrocerySys.Application.DTOs;
using GrocerySys.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace GrocerySys.API.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(AuthService authService, JwtTokenGenerator jwtTokengenerator)
    {
        _authService = authService;
        _jwtTokenGenerator = jwtTokengenerator;
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
        var user = await _authService.LoginAsync(dto);

        if (user == null)
        {
            return Unauthorized("Invalid Credentials");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return Ok(new
        {
            token,
            user = new
            {
                user.UserId,
                user.Username,
                user.Role
            }
        });
    }
}
