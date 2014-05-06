using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Utils
{
    public class HandlerFactory
    {

             protected static readonly HandlerFactory handlerFactory = new HandlerFactory();

            protected static readonly IUnityContainer unityContainer = new UnityContainer();

            protected HandlerFactory()
            {
            }


            static HandlerFactory()
            {
                var types = AllClasses.FromLoadedAssemblies();
                var repositoryTypes = (from type in types
                                       let implementedRepositoryInterfaces = type.GetInterfaces()
                                            .Where(x => (x.AssemblyQualifiedName == typeof(IEventHandlerFactory).AssemblyQualifiedName))
                                       where implementedRepositoryInterfaces.Any()
                                       select type).ToList();

                // Register all repository interfaces and implementations mapping in unity container.
                unityContainer.RegisterTypes(repositoryTypes,
                   WithMappings.FromAllInterfaces,
                   WithName.Default,
                   WithLifetime.PerResolve);
            }


            public static HandlerFactory Current
            {
                get
                {
                    return handlerFactory;
                }
            }

            public virtual T Get<T>()
            {
                return unityContainer.Resolve<T>();
            }
        
        


    }
}
