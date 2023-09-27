using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using SuperHeroBlazorWebApp.Server.Components;
using SuperHeroBlazorWebApp.Server.Models.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetService<NavigationManager>();
    if (navigationManager != null)
    {
        try
        {
            return new HttpClient
            {
                Timeout = new TimeSpan(2, 0, 0),
                BaseAddress = new Uri($"{navigationManager.BaseUri}api/")
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not initialize navigationManager {ex.Message}");
        }
    }

    var baseUrl = builder.Configuration[$"BaseUrl"];
    return new HttpClient
    {
        Timeout = new TimeSpan(2, 0, 0),
        BaseAddress = baseUrl != null ? new Uri($"{baseUrl}/api") : null
    };
});
builder.Services.AddDbContext<SuperHeroBlazorContext>((opt) =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SuperHeroBlazorWebApp.Client._Imports).Assembly);
app.MapControllers();
app.Run();
