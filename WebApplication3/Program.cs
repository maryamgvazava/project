using WebApplication3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<RailwayService>();
builder.Services.AddSingleton<PDFService>();
builder.Services.AddRazorPages(options => {
    options.Conventions.AddPageRoute("/Error", "/Error");
});

// Register services
builder.Services.AddHttpClient<RailwayService>();
builder.Services.AddSingleton<PDFService>();

var app = builder.Build();

app.UseExceptionHandler("/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();