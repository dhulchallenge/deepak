using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Utils
{
    public class EventFactory
    {

        protected static readonly EventFactory eventFactory = new EventFactory();
       
        protected static readonly IUnityContainer unityContainer = new UnityContainer();
             
        protected EventFactory()
        {
        }

        
        static EventFactory()
        {
            var types = AllClasses.FromLoadedAssemblies();
            var repositoryTypes = (from type in types
                                   let implementedRepositoryInterfaces = type.GetInterfaces()
                                        .Where(x => (x.AssemblyQualifiedName == typeof(IEventBus).AssemblyQualifiedName))
                                   where implementedRepositoryInterfaces.Any()
                                   select type).ToList();

            // Register all repository interfaces and implementations mapping in unity container.
            unityContainer.RegisterTypes(repositoryTypes,
               WithMappings.FromAllInterfaces,
               WithName.Default,
               WithLifetime.PerResolve);
        }

       
        public static EventFactory Current
        {
            get
            {
                return eventFactory;
            }
        }

        public virtual T Get<T>()
        {
            return unityContainer.Resolve<T>();
        }



    }
}
