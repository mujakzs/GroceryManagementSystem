using GrocerySys.UI;
using GrocerySys.UI.Services.Authentication;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// =============================
// API Base URL
// =============================
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new Exception("ApiBaseUrl is not configured.");
}

// =============================
// JWT Handler
// =============================
builder.Services.AddScoped<JwtAuthorizationMessageHandler>();
builder.Services.AddScoped<TokenProvider>();

// =============================
// HttpClient with JWT pipeline
// =============================
builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})
.AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

// =============================
// Razor Components
// =============================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// =============================
// Middleware
// =============================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
