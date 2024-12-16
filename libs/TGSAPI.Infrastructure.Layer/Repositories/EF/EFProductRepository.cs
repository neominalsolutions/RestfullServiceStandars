using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;
using TGSAPI.Persistence.Layer.EF;

namespace TGSAPI.Infrastructure.Layer.Repositories.EF
{
  public class EFProductRepository : EFRepository<AppDbContext, Product, int>, IProductRepository
  {
    public EFProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }


    public override async Task CreateAsync(Product entity)
    {
       await base.CreateAsync(entity);
    }
  }
}
