using System;

namespace RefaceCore.CommandBus.Demo.Commands
{
    public class MyCommand2 :
        IDisposable,
        IGoodbyeCommand,
        IHelloCommand
    {
        public string UserName { get; private set; }

        public MyCommand2(string userName)
        {
            UserName = userName;
        }

        public void Dispose()
        {
        }
    }
}
