using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGSAPI.Domain.Layer.Entities
{
  public class Category : Entity<Guid>
  {
    public required string Name { get; set; }

    public Category()
    {
      Id = Guid.NewGuid();
    }
  }
}
