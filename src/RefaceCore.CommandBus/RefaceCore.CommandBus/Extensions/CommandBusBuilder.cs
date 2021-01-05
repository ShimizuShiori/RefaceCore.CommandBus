using System;
using System.Collections.Generic;

namespace RefaceCore.CommandBus.Extensions
{
    public class CommandBusBuilder : ICommandBusBuilder
    {
        public IDictionary<Type, Type> HandlerTypeToImplementTypeMap = new Dictionary<Type, Type>();
        public Type CacheType { get; private set; } = typeof(DefaultCache);
        public Type CommandBusType { get; private set; } = typeof(DefaultCommandBus);
        public Type CommandHandlerTypesReflectorType { get; private set; } = typeof(DefaultCommandHandlerTypesReflector);
        public Type CommandHandlerInvokerType { get; private set; } = typeof(DefaultCommandHandlerInvoker);
        public Type CommandHandlerInstanceCreatorType { get; private set; } = typeof(DefaultCommandHandlerInstanceCreator);

        public ICommandBusBuilder ReplaceCache<T>() where T : ICache
        {
            this.CacheType = typeof(T);
            return this;
        }

        public ICommandBusBuilder ReplaceCommandBus<T>() where T : ICommandBus
        {
            this.CommandBusType = typeof(T);
            return this;
        }

        public ICommandBusBuilder AddCommandHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>
        {
            return this.AddCommandHandler(typeof(TCommand), typeof(THandler));
        }

        public ICommandBusBuilder ReplaceCommandHandlerInstanceCreator<T>() where T : ICommandHandlerInstanceCreator
        {
            this.CommandHandlerInstanceCreatorType = typeof(T);
            return this;
        }

        public ICommandBusBuilder ReplaceCommandHandlerInvoker<T>() where T : ICommandHandlerInvoker
        {
            this.CommandHandlerInvokerType = typeof(T);
            return this;
        }

        public ICommandBusBuilder ReplaceCommandHandlerTypesReflector<T>() where T : ICommandHandlerTypesReflector
        {
            this.CommandHandlerTypesReflectorType = typeof(T);
            return this;
        }

        public ICommandBusBuilder AddCommandHandler(Type commandType, Type handlerType)
        {
            if (!HandlerIsForThisCommand(commandType, handlerType))
                throw new InvalidOperationException($"该处理器不能处理该命令");

            if (HandlerTypeToImplementTypeMap.ContainsKey(commandType))
                throw new InvalidOperationException($"已添加了对命令 {commandType} 的处理器");

            this.HandlerTypeToImplementTypeMap[commandType] = handlerType;
            return this;
        }

        private bool HandlerIsForThisCommand(Type commandType, Type handlerType)
        {
            return typeof(ICommandHandler<>).MakeGenericType(commandType).IsAssignableFrom(handlerType);
        }
    }
}
