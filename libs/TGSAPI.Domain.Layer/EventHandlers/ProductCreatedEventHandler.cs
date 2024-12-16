using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGSAPI.Domain.Layer.Events;

namespace TGSAPI.Domain.Layer.EventHandlers
{
  public class ProductCreatedEventHandler : INotificationHandler<ProductCreated>
  {
    // istersek bu bir hizmet repoya bağlanıp veriyi çekebiliriz.

    public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
    {
      await Console.Out.WriteLineAsync("Ürün kaydedildi. Mail atıldı");
    }
  }
}
