using System;

namespace RefaceCore.CommandBus
{
    public interface ICommandBusBuilder
    {
        /// <summary>
        /// 替换 <see cref="ICommandBus"/> 的实现类，若替换此类，则不需要再使用其它 Replace 方法，因为 <see cref="DefaultCommandBus"/> 依赖其它组件.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder ReplaceCommandBus<T>() where T : ICommandBus;

        /// <summary>
        /// 替换 <see cref="ICache"/> 的实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder ReplaceCache<T>() where T : ICache;

        /// <summary>
        /// 替换 <see cref="ICommandHandlerInstanceCreator"/> 的实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder ReplaceCommandHandlerInstanceCreator<T>() where T : ICommandHandlerInstanceCreator;

        /// <summary>
        /// 替换 <see cref="ICommandHandlerInvoker"/> 的实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder ReplaceCommandHandlerInvoker<T>() where T : ICommandHandlerInvoker;

        /// <summary>
        /// 替换 <see cref="ICommandHandlerTypesReflector"/> 的实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder ReplaceCommandHandlerTypesReflector<T>() where T : ICommandHandlerTypesReflector;

        /// <summary>
        /// 添加一个命令处理器
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <returns></returns>
        ICommandBusBuilder AddCommandHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : ICommandHandler<TCommand>;

        /// <summary>
        /// 添加一个命令处理器
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="handlerType"></param>
        /// <returns></returns>
        ICommandBusBuilder AddCommandHandler(Type commandType, Type handlerType);
    }
}
