using System;
using System.Collections.Generic;
using System.Linq;

namespace RefaceCore.CommandBus
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerTypesReflector commandHandlerTypeReflector;
        private readonly ICommandHandlerInvoker commandHandlerInvoker;
        private readonly ICache cache;
        private readonly ICommandHandlerInstanceCreator commandHandlerInstanceCreator;

        public DefaultCommandBus(ICommandHandlerTypesReflector commandHandlerTypeReflector, ICommandHandlerInvoker commandHandlerInvoker, ICache cache, ICommandHandlerInstanceCreator commandHandlerInstanceCreator)
        {
            this.commandHandlerTypeReflector = commandHandlerTypeReflector;
            this.commandHandlerInvoker = commandHandlerInvoker;
            this.cache = cache;
            this.commandHandlerInstanceCreator = commandHandlerInstanceCreator;
        }

        public void Dispatch(object command)
        {
            Type commandType = command.GetType();
            IEnumerable<Type> commandHandlerTypes = GetCommandHandlerTypes(commandType);
            IEnumerable<ICommandHandler> handlers = CreateCommandHandlerInstances(commandHandlerTypes);
            InvokeHandlers(handlers, command);

        }

        private void InvokeHandlers(IEnumerable<ICommandHandler> handlers, object command)
        {
            foreach (ICommandHandler handler in handlers)
                commandHandlerInvoker.Invoke(handler, command);
        }

        private IEnumerable<ICommandHandler> CreateCommandHandlerInstances(IEnumerable<Type> commandHandlerTypes)
        {
            return commandHandlerTypes
                .Select(t => commandHandlerInstanceCreator.Create(t))
                .Where(h => h != null)
                .Cast<ICommandHandler>();
        }

        private IEnumerable<Type> GetCommandHandlerTypes(Type commandType)
        {
            return this.cache.GetOrDefault($"CommandHandlerTypes_{commandType}", key => commandHandlerTypeReflector.GetCommandHandlerTypes(commandType));
        }
    }
}
