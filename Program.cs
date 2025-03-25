using WebApplication3.Services;
using WebApplication3.Models;
using WebApplication3.Models.ApiModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<IRailwayService, RailwayService>();  // Now recognized
builder.Services.AddScoped<IPDFService, PDFService>();  // Now recognized

var app = builder.Build();

// Configure the HTTP request pipeline
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