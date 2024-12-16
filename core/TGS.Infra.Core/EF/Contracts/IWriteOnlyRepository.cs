using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGS.Infra.Core.EF.Contracts
{
  public interface IWriteOnlyRepository<TEntity,TKey>
    where TEntity:Entity<TKey>
    where TKey:IComparable
  {
    Task CreateAsync(TEntity entity); // Added State
    Task UpdateAsync(TEntity entity); // Modified State
    Task DeleteAsync(TKey Id); // Removed State
  }
}
