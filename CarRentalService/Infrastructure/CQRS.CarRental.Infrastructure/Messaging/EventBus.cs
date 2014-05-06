using CQRS.CarRental.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public class EventBus : IEventBus
    {
        //private IEventHandlerFactory _eventHandlerFactory;

        //public EventBus(IEventHandlerFactory eventHandlerFactory)
        //{
        //    _eventHandlerFactory = eventHandlerFactory;
        //}

        public void Publish<T>(T @event) where T : Event
        {


            var _eventHandlerFactory = HandlerFactory.Current.Get<IEventHandlerFactory>();
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            handlers.Handle(@event);
            
        }
    }
}
