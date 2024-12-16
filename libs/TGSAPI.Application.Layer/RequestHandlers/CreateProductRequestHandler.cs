using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Application.Layer.Requests;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Application.Layer.RequestHandlers
{
  public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
  {
    private readonly IProductService productService;

    public CreateProductRequestHandler(IProductService productService)
    {
      this.productService = productService;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
      // apidan veri çekme yapılabilir

      var entity = new Product { Name = request.Name };
      await this.productService.SaveAsync(entity);

      // notification fırlat
      // log süreçleri

      return await Task.FromResult(new CreateProductResponse(1));
    }
  }
}
