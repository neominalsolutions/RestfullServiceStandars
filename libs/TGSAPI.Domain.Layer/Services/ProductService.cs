using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository productRepository;


    public ProductService(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

    public Task SaveAsync(Product product)
    {
      Console.Out.WriteAsync("Domain Layer Product Service");
 
     this.productRepository.CreateAsync(product);

      return Task.CompletedTask;

    }

  }
}
