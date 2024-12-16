using Microsoft.EntityFrameworkCore;
using Serilog;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Application.Layer.Contracts;
using TGSAPI.Application.Layer.RequestHandlers;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Services;
using TGSAPI.Infrastructure.Layer.Repositories.EF;
using TGSAPI.Persistence.Layer.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Persistance Layer
builder.Services.AddDbContext<AppDbContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

// Application Layer
builder.Services.AddScoped<ICreateProductApplicationService, CreateProductApplicationService>();

// Domain Layer
builder.Services.AddScoped<IProductService, ProductService>();

// Infra Layer
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IUnitOfwork, AppDbUnitOfWork>();


// Serilog Connection

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

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
