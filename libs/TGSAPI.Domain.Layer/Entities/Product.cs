using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;

namespace TGSAPI.Domain.Layer.Entities
{
  public class Product : Entity<int>
  {
    public required string Name { get; set; }

 
  }
}
