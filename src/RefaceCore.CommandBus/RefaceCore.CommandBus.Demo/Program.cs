using Microsoft.Extensions.DependencyInjection;
using RefaceCore.CommandBus.Demo.CommandHandlers;
using RefaceCore.CommandBus.Demo.Commands;
using System;

namespace RefaceCore.CommandBus.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider sp = new ServiceCollection()
                .AddCommandBus(builder =>
                {
                    builder
                        .AddCommandHandler<HelloCommandHandler>()
                        .AddCommandHandler<GoodbyeCommandHandler>()
                    ;
                })
                .BuildServiceProvider();

            ICommandBus commandBus = sp.GetService<ICommandBus>();


            commandBus.Dispatch(new MyCommand("Felix"));

            commandBus.Dispatch(new MyCommand("Cynthia"));

            commandBus.Dispatch(new MyCommand2("Felix"));

            commandBus.Dispatch(new MyCommand2("Cynthia"));

            Console.ReadLine();
        }
    }
}
