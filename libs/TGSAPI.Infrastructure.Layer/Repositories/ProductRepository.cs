using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Infrastructure.Layer.Repositories
{
  public class ProductRepository : IProductRepository
  {
    public Task CreateAsync(Product product)
    {
      Console.Out.WriteAsync("Infra Layer Product Repo");
      return Task.CompletedTask;
    }
  }
}
