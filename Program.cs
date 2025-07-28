using movieApp.Data;                // So you can use your AppDbContext
using Microsoft.EntityFrameworkCore; // For EF Core tools
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // Add OpenAPI support
builder.Services.AddDbContext<AppDbContext>(options =>      // review this cause im confused
    options.UseSqlite("Data Source=movies.db"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapOpenApi();
app.UseSwaggerUi(options =>
{
    options.DocumentPath = "/openapi/v1.json";
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}")     //this is what needs to be changes to link it to the right controller
    .WithStaticAssets();


app.Run();
