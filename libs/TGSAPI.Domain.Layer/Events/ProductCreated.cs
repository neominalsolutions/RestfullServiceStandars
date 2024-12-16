using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGSAPI.Domain.Layer.Events
{
  // Eventler sadece ihtiyaç kadar gönderelim
  public record ProductCreated(int Id, string Name):INotification;
  
}
