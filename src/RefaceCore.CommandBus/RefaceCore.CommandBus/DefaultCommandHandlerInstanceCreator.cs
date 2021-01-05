using System;

namespace RefaceCore.CommandBus
{
    public class DefaultCommandHandlerInstanceCreator : ICommandHandlerInstanceCreator
    {
        private readonly IServiceProvider container;

        public DefaultCommandHandlerInstanceCreator(IServiceProvider container)
        {
            this.container = container;
        }

        public ICommandHandler Create(Type commandHandlerType)
        {
            object service = container.GetService(commandHandlerType);
            return (ICommandHandler)service;
        }
    }
}
