using GrocerySys.UI.Models.Response;
using System.Net.Http.Json;



namespace GrocerySys.UI.Services.Authentication;

public class AuthApiService
{
    private readonly HttpClient _http;

    public AuthApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> RegisterAsync(string username, string password, string role)
    {
        var response = await _http.PostAsJsonAsync(
            "/api/auth/register", new { username, password, role });

        return response.IsSuccessStatusCode;
    }

    public async Task<string?> LoginAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync(
            "api/auth/login", new { username, password });
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        return result?.Token;
    }
}

