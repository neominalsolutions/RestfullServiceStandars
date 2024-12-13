using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Contracts
{
  // Application Katmanı için Port görevi görür
  public interface IProductService
  {
    Task SaveAsync(Product product);
  }
}
