using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS.Domain.Core.Contracts
{
  public abstract class Entity<TKey>
    where TKey : IComparable
  {

    public TKey Id { get; set; }
    public DateTime CreatedAt { get; init; }

    protected Entity()
    {
      CreatedAt = DateTime.Now;
    }
  }
}
