using WebApplication3.Services;
using WebApplication3.Models;
using WebApplication3.Models.ApiModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<IRailwayService, RailwayService>();
builder.Services.AddScoped<IPDFService, PDFService>();  

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
