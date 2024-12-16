using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Contracts
{
  // Infra katmanı için Port görevi görür
  public interface IProductRepository:IRepository<Product,int>
  { }
}
