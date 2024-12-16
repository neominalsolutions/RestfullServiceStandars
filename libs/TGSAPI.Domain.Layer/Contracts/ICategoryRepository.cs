using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Domain.Layer.Contracts
{
  public interface ICategoryRepository:IRepository<Category,Guid>
  {
  }
}
