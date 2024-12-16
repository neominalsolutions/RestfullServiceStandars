using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGS.Infra.Core.EF.Contracts
{
  public interface IRepository<TEntity,TKey>:
    IReadOnlyRepository<TEntity,TKey>,
    IWriteOnlyRepository<TEntity,TKey>
    where TEntity:Entity<TKey>
    where TKey:IComparable
  {

  }
}
