
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Practices.Unity;
using CQRS.CarRental.Repository;

using CQRS.CarRental.Repository.Foundation.Foundation;

namespace CQRS.CarRental.Infrastructure.Utils
{
   
    public class RepositoryFactory
    {
       
        protected static readonly RepositoryFactory repositoryFactory = new RepositoryFactory();
       
        protected static readonly IUnityContainer unityContainer = new UnityContainer();
             
        protected RepositoryFactory()
        {
        }

        
        static RepositoryFactory()
        {
            var types = AllClasses.FromLoadedAssemblies();
            var repositoryTypes = (from type in types
                                   let implementedRepositoryInterfaces = type.GetInterfaces()
                                        .Where(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRepository<>)))
                                   where implementedRepositoryInterfaces.Any()
                                   select type).ToList();

            // Register all repository interfaces and implementations mapping in unity container.
            unityContainer.RegisterTypes(repositoryTypes,
               WithMappings.FromAllInterfaces,
               WithName.Default,
               WithLifetime.PerResolve);
        }

       
        public static RepositoryFactory Current
        {
            get
            {
                return repositoryFactory;
            }
        }

        public virtual T Get<T>()
        {
            return unityContainer.Resolve<T>();
        }
    }
}
