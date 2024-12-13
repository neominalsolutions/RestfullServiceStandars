using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Application.Layer.Requests;

namespace TGSAPI.Application.Layer.Contracts
{
    public interface ICreateProductApplicationService
    {
        Task HandleAsync(CreateProductDto request);
    }
}
