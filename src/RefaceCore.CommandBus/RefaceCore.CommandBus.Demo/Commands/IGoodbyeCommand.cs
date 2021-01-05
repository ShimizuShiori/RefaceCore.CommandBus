namespace RefaceCore.CommandBus.Demo.Commands
{
    public interface IGoodbyeCommand : ICommand
    {
        string UserName { get; }
    }
}
