using GrocerySys.UI.Models.DTOs.Response;
using GrocerySys.UI.Models.Request;
using System.Net.Http.Json;

namespace GrocerySys.UI.Services.Authentication;

public class AuthApiService
{
    private readonly HttpClient _http;

    public AuthApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/register", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<string?> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", request);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        return result?.Token;
    }
}
