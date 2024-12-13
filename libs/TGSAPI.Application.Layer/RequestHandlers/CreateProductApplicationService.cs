using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Application.Layer.Contracts;
using TGSAPI.Application.Layer.Requests;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Application.Layer.RequestHandlers
{
  public class CreateProductApplicationService : ICreateProductApplicationService
  {
    private readonly IProductService productService;

    public CreateProductApplicationService(IProductService productService)
    {
      this.productService = productService;
    }
    public Task HandleAsync(CreateProductDto request)
    {
      var entity = new Product { Name = request.Name };
      Console.Out.WriteAsync("Application Layer  CreateProductApplicationService");
      return productService.SaveAsync(entity);
    }
  }
}
