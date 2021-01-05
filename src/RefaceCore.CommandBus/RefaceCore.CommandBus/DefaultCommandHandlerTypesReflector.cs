using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RefaceCore.CommandBus
{
    public class DefaultCommandHandlerTypesReflector : ICommandHandlerTypesReflector
    {
        public IEnumerable<Type> GetCommandHandlerTypes(Type commandType)
        {
            Type[] interfaceTypes = commandType.GetInterfaces();
            ICollection<Type> result = new List<Type>();
            foreach (Type interfaceType in interfaceTypes)
            {
                if (!IsCommand(interfaceType))
                    continue;

                result.Add(typeof(ICommandHandler<>).MakeGenericType(interfaceType));
            }
            return result;
        }

        private bool IsCommand(Type interfaceType)
        {
            return typeof(ICommand).IsAssignableFrom(interfaceType);
        }
    }
}
