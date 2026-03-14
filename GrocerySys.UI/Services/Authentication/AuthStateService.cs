namespace GrocerySys.UI.Services.Authentication;


//Constructor Dependency Injection.
public class AuthStateService
{
    private readonly TokenProvider _tokenProvider;

    public AuthStateService(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(_tokenProvider.Token);

    public void Logout()
    {
        _tokenProvider.Token = null;
    }
}
