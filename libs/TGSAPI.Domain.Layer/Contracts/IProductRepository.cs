using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Contracts
{
  // Infra katmanı için Port görevi görür
  public interface IProductRepository
  {
    Task CreateAsync(Product product);
  }
}
