using DIContainer.Container.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace DIContainer.Container
{
    class InstanceBuilder
    {
        public static object CreateInstance(RegisteredComponent registeredComponent, IContainer container)
        {
            var componentType = registeredComponent.GetComponentType();

            if ((componentType.IsInterface) || (componentType.IsAbstract))
            {
                throw new InvalidOperationException($"Type {componentType} cannot have instance");
            }

            var method = typeof(Container).GetMethod("Contains");
            var constructor = componentType
                .GetConstructors()
                .FirstOrDefault();

            if (constructor == null)
            {
                throw new InvalidOperationException($"Cannot resolve {registeredComponent.GetComponentType()}  ");
            }

            return Activator.CreateInstance(componentType, ResolveArguments(constructor, container));
        }


        private static object[] ResolveArguments(ConstructorInfo constructor, IContainer container)
        {
            var parameters = new List<object>();
            var method = typeof(Container).GetMethod("Resolve");

            foreach (var parameter in constructor.GetParameters())
            {
                parameters.Add(method
                    .MakeGenericMethod(parameter.ParameterType)
                    .Invoke(container, null));
            }

            return parameters.ToArray();
        }
    }
}
