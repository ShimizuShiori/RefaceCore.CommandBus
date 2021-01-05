using System;

namespace RefaceCore.CommandBus
{
    public static class CommandBusBuilderExtension
    {
        public static ICommandBusBuilder AddCommandHandler<TCommandHandler>(this ICommandBusBuilder builder)
            where TCommandHandler : ICommandHandler
        {
            Type interfaceType = typeof(TCommandHandler).GetInterface(typeof(ICommandHandler<>).FullName);
            Type commandType = interfaceType.GetGenericArguments()[0];

            return builder.AddCommandHandler(commandType, typeof(TCommandHandler));
        }
    }
}
