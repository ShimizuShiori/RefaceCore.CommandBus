using RefaceCore.CommandBus;
using RefaceCore.CommandBus.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommandBus(this IServiceCollection services, Action<ICommandBusBuilder> initor = null)
        {
            CommandBusBuilder builder = new CommandBusBuilder();

            initor?.Invoke(builder);

            services
                .AddScoped(typeof(ICommandBus), builder.CommandBusType)
                .AddScoped(typeof(ICache), builder.CacheType)
                .AddScoped(typeof(ICommandHandlerInstanceCreator), builder.CommandHandlerInstanceCreatorType)
                .AddScoped(typeof(ICommandHandlerInvoker), builder.CommandHandlerInvokerType)
                .AddScoped(typeof(ICommandHandlerTypesReflector), builder.CommandHandlerTypesReflectorType);

            foreach (var pair in builder.HandlerTypeToImplementTypeMap)
            {
                Type commandType = pair.Key;
                Type implementorType = pair.Value;

                Type serviceType = typeof(ICommandHandler<>).MakeGenericType(commandType);

                services.AddScoped(serviceType, implementorType);
            }

            return services;
        }
    }
}
