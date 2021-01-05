using System;

namespace RefaceCore.CommandBus
{
    public interface ICommandHandlerInstanceCreator
    {
        ICommandHandler Create(Type commandHandlerType);
    }
}
