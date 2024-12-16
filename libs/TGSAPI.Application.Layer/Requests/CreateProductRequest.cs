using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGSAPI.Application.Layer.Requests
{
  public record CreateProductResponse(int Id);
  public record CreateProductRequest(string Name):IRequest<CreateProductResponse>;
  
}
