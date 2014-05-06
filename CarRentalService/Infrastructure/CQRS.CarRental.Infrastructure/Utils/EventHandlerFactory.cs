using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        public IEventHandler<T> GetHandlers<T>() where T : Event
        {


            var container = new UnityContainer();
            var handlers = GetHandlerType<T>().ToList();

            foreach (var ha in handlers)
            {
                var type = Type.GetType(ha.FullName);
                var resolvedInstance = (IEventHandler<T>)container.Resolve(type);
                return resolvedInstance;
                break;
            }
            return null;   

        }

        private static IEnumerable<Type> GetHandlerType<T>() where T : Event
        {
            var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
