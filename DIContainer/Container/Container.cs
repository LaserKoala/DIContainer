using DIContainer.Container.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIContainer.Container
{
    public class Container : IContainer
    {
        private readonly IList<IRegisteredComponent> registeredComponents = new List<IRegisteredComponent>();
        // private bool IsBuilded = false;


        public IRegisteredComponent RegisterType<TComponent>()
        {
            var componentType = typeof(TComponent);
            var registeredComponent = registeredComponents
                                        .Where(regComponent => regComponent.GetComponentType() == componentType)
                                        .FirstOrDefault();

            if (registeredComponent != null)
            {
                return registeredComponent;
            }
            var newComponent = new RegisteredComponent(componentType);
            registeredComponents.Add(newComponent);

            return newComponent;
        }


        public SomeType Resolve<SomeType>()
        {
            var component = registeredComponents
                .Where(regComponent => regComponent.IsService<SomeType>())
                .FirstOrDefault();

            if (component == null)
            {
                throw new ArgumentException($"Component {typeof(SomeType).Name} is not registered");
            }

            return (SomeType)component.GetInstance(this);
        }


        public bool Contains<SomeType>()
        {
            if (registeredComponents
                 .Where(registeredComponent => registeredComponent.IsService<SomeType>())
                 .FirstOrDefault()
                 != null)
            {
                return true;
            }

            return false;
        }
    }
}
