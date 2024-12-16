using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;
using TGSAPI.Persistence.Layer.EF;

namespace TGSAPI.Infrastructure.Layer.Repositories.EF
{
  public class EFCategoryRepository : EFRepository<AppDbContext, Category, Guid>, ICategoryRepository
  {
    public EFCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
  }
}
