using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositoriesFromAssembly(this IServiceCollection serviceCollection, Assembly repositoryAssembly)
        {
            IEnumerable<Type> repositoryImplTypes = repositoryAssembly
                .GetTypes()
                .Where(t => t is { BaseType: { IsGenericType: true }, IsAbstract: false } &&
                            (t.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>) ||
                             t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(BaseSoftDeletableRepository<>)))
                .ToArray();

            foreach (var repositoryImplType in repositoryImplTypes)
            {
                Type? interfaceType = repositoryImplType
                    .GetInterfaces()
                    .SingleOrDefault(it => !it.IsGenericType &&
                                           (it.GetInterfaces().Any(bit => bit.IsGenericType && (bit.GetGenericTypeDefinition() == typeof(IRepository<>) ||
                                               bit.GetGenericTypeDefinition() == typeof(ISoftDeletableRepository<>)))));

                if (interfaceType != null)
                {
                    serviceCollection.AddScoped(interfaceType, repositoryImplType);
                }
            }

            return serviceCollection;
        }
    }
}
