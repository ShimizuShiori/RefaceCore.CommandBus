using System;

namespace RefaceCore.CommandBus.Demo.Commands
{
    public class MyCommand :
        IDisposable,
        IHelloCommand,
        IGoodbyeCommand
    {
        public string UserName { get; private set; }

        public MyCommand(string userName)
        {
            UserName = userName;
        }

        public void Dispose()
        {
        }
    }
}
