using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository productRepository;
    private readonly IUnitOfwork unitOfwork;


    public ProductService(IProductRepository productRepository, IUnitOfwork unitOfwork)
    {
      this.productRepository = productRepository;
      this.unitOfwork = unitOfwork;
    }

    public async Task SaveAsync(Product product)
    {
      
 
     await this.productRepository.CreateAsync(product);
      await this.unitOfwork.CommitAsync();


    }

  }
}
