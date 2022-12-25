using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Vendors;
using PurchaseOrderBackEnd.Products;
using PurchaseOrderBackEnd.PurchaseOrders;
using PurchaseOrderBackEnd.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using PurchaseOrderBackEnd.Migrations;
using PurchaseOrderBackEnd.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VendorAndProductsDBContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("VendorProductsConnectionString")), ServiceLifetime.Singleton);
builder.Services.AddScoped<VendorRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<PurchaseOrderRepository>();
builder.Services.AddScoped<PurchaseOrderLineItemRepository>();
builder.Services.AddScoped<PurchaseOrderDAO>();

builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
