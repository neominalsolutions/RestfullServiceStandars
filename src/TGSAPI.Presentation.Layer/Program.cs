using TGSAPI.Application.Layer.Contracts;
using TGSAPI.Application.Layer.RequestHandlers;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Services;
using TGSAPI.Infrastructure.Layer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application Layer
builder.Services.AddScoped<ICreateProductApplicationService, CreateProductApplicationService>();

// Domain Layer
builder.Services.AddScoped<IProductService, ProductService>();

// Infra Layer
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();