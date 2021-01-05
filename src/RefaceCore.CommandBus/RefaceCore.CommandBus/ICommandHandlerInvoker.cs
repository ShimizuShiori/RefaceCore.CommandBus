namespace RefaceCore.CommandBus
{
    public interface ICommandHandlerInvoker
    {
        void Invoke(ICommandHandler handler, object command);
    }
}
