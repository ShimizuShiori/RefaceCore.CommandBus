namespace RefaceCore.CommandBus.Demo.Commands
{
    public interface IHelloCommand : ICommand
    {
        string UserName { get; }
    }
}
