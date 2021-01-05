namespace RefaceCore.CommandBus
{
    /// <summary>
    /// 标记类接口
    /// </summary>
    public interface ICommandHandler
    {
    }


    /// <summary>
    /// 命令处理器
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
