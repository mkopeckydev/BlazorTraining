using BlazorTraining.Components;
using BlazorTraining.Services;
using BlazorTraining.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthService>();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "training_blazor_token";
        options.LoginPath = "/" + PageNames.Login;
        options.Cookie.MaxAge = TimeSpan.FromHours(24);
        options.AccessDeniedPath = "/" + PageNames.Denied; 
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/" + PageNames.Error, createScopeForErrors: true);
    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
