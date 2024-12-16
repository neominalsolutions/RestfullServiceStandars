using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;
using TGSAPI.Domain.Layer.Events;

namespace TGSAPI.Domain.Layer.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository productRepository;
    private readonly IUnitOfwork unitOfwork;
    private readonly IMediator mediator;


    public ProductService(IProductRepository productRepository, IUnitOfwork unitOfwork, IMediator mediator)
    {
      this.productRepository = productRepository;
      this.unitOfwork = unitOfwork;
      this.mediator = mediator;
    }

    public async Task SaveAsync(Product product)
    {
      
 
     await this.productRepository.CreateAsync(product);
      await this.unitOfwork.CommitAsync();

      // süreci delegate et. Kaydettikten sonra yapılacak işlemler ile 
      var @event = new ProductCreated(product.Id,product.Name);
      await this.mediator.Publish(@event);

    }

  }
}
