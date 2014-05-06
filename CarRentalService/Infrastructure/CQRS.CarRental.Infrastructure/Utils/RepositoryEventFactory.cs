using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.CarRental.Infrastructure.Utils
{
   
        public class RepositoryEventFactory
        {

            protected static readonly RepositoryEventFactory repositoryeventFactory = new RepositoryEventFactory();

            protected static readonly IUnityContainer unityContainer = new UnityContainer();

            protected RepositoryEventFactory()
            {
            }


            static RepositoryEventFactory()
            {
                var types = AllClasses.FromLoadedAssemblies();
                var repositoryTypes = (from type in types
                                       let implementedRepositoryInterfaces = type.GetInterfaces()
                                            .Where(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(CQRS.CarRental.Events.Repository.Foundation.IRepository<>)))
                                       where implementedRepositoryInterfaces.Any()
                                       select type).ToList();

                // Register all repository interfaces and implementations mapping in unity container.
                unityContainer.RegisterTypes(repositoryTypes,
                   WithMappings.FromAllInterfaces,
                   WithName.Default,
                   WithLifetime.PerResolve);
            }


            public static RepositoryEventFactory Current
            {
                get
                {
                    return repositoryeventFactory;
                }
            }

            public virtual T Get<T>()
            {
                return unityContainer.Resolve<T>();
            }
        }



    
}
