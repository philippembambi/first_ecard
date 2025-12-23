using First.Ecard.Presentation.UI.Components;
using First.Ecard.Presentation.UI.Components.interfaces;
using First.Ecard.Presentation.UI.Components.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5134/api/")});
builder.Services.AddLogging();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<TokenStorageService>();
builder.Services.AddScoped<UserSessionService>();
// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
