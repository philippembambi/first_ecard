using First.Ecard.Presentation.UI.Components;
using First.Ecard.Presentation.UI.Components.interfaces;
using First.Ecard.Presentation.UI.Components.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using First.Ecard.Presentation.UI.Components.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5134/api/")});
builder.Services.AddLogging();
builder.Services.AddBlazorBootstrap();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        //options.AccessDeniedPath = "/access-denied";
        options.Cookie.Name = "FirstEcard.Auth";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
    })
;
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<DateFormatter>();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.UseAntiforgery(); // should be after UseAuthentication and UseAuthorization
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
