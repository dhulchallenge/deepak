using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Utils
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
        
            var container = new UnityContainer();
            var handlers = GetHandlerTypes<T>().ToList();

            foreach (var ha in handlers)
            {
                var type = Type.GetType(ha.FullName);
                var resolvedInstance = (ICommandHandler<T>)container.Resolve(type);
                return resolvedInstance;
                break;
            }
            return null;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {                      

            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
