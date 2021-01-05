using RefaceCore.CommandBus.Demo.Commands;
using System;

namespace RefaceCore.CommandBus.Demo.CommandHandlers
{
    public class GoodbyeCommandHandler : ICommandHandler<IGoodbyeCommand>
    {
        public void Handle(IGoodbyeCommand command)
        {
            Console.WriteLine($"CU , {command.UserName}");
        }
    }
}
