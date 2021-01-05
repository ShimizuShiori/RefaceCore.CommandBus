using System;
using System.Collections.Generic;

namespace RefaceCore.CommandBus
{
    public interface ICommandHandlerTypesReflector
    {
        IEnumerable<Type> GetCommandHandlerTypes(Type commandType);
    }
}
