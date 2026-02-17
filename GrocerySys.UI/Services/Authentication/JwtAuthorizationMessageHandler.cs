using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GrocerySys.UI.Services.Authentication;

public class JwtAuthorizationMessageHandler : DelegatingHandler
{
    private readonly TokenProvider _tokenProvider;

    public JwtAuthorizationMessageHandler(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(_tokenProvider.Token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _tokenProvider.Token);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
