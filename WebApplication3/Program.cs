using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Razor.Templating.Core;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;
var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRailwayService, RailwayService>();
builder.Services.AddSingleton<ITempDataProvider, SessionStateTempDataProvider>();
builder.Services.AddHttpClient<IStationService, StationsService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<PDF>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
});
var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapGet("invoice-report", async (PDF pdf) =>
{
  
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
