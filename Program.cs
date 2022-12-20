using Microsoft.EntityFrameworkCore;
using PurchaseOrderBackEnd.Vendors;
using PurchaseOrderBackEnd.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VendorAndProductsDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VendorProductsConnectionString")));

builder.Services.AddScoped<VendorRepository>();

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
