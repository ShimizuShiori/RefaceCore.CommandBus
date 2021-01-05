using System;
using System.Reflection;

namespace RefaceCore.CommandBus
{
    public class DefaultCommandHandlerInvoker : ICommandHandlerInvoker
    {
        public void Invoke(ICommandHandler handler, object command)
        {
            MethodInfo method = handler.GetType().GetMethod("Handle", new Type[] { command.GetType() });
            method.Invoke(handler, new object[] { command });
        }
    }
}
