namespace RefaceCore.CommandBus
{
    /// <summary>
    /// 命令总线
    /// </summary>
    public interface ICommandBus
    {
        void Dispatch(object command);
    }
}
