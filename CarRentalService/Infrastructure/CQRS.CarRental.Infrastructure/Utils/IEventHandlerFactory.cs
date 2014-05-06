using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public interface  IEventHandlerFactory
    {
        IEventHandler<T> GetHandlers<T>() where T : Event;
    }
}
