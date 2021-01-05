using RefaceCore.CommandBus.Demo.Commands;
using System;

namespace RefaceCore.CommandBus.Demo.CommandHandlers
{
    public class HelloCommandHandler : ICommandHandler<IHelloCommand>
    {
        public void Handle(IHelloCommand command)
        {
            Console.WriteLine($"Hello , {command.UserName}");
        }
    }
}
