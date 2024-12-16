using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGS.Domain.Core.Contracts;
using TGSAPI.Application.Layer.Contracts;
using TGSAPI.Application.Layer.RequestHandlers;

namespace TGSAPI.Application.Layer
{
  // assembly ait depencieslerin yüklendiği modül dosyası
  public static class ApplicationModule 
  {
    public static IServiceCollection RegisterApplicationDependecies(this IServiceCollection services)
    {
      return services.AddScoped<ICreateProductApplicationService, CreateProductApplicationService>();
    }
  }
}
