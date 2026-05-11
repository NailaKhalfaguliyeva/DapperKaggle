using DapperKaggle.Context;
using DapperKaggle.Services.Dashboard;
using DapperKaggle.Services.OrderServices;
using DapperKaggle.Services.ProductServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddScoped<DashboardStatsQueryService>();
builder.Services.AddScoped<DashboardTopQueryService>();
builder.Services.AddScoped<DashboardChartQueryService>();

builder.Services.AddScoped<OrderQueryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ProductQueryService>();
builder.Services.AddScoped<IProductService, ProductService>(); 
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();