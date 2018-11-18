using DIContainer.Container.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIContainer.Container
{
    public class RegisteredComponent : IRegisteredComponent
    {
        private List<Type> servicesList = new List<Type>();
        private bool isSingleInstance = false;
        private object Instance = null;

        public RegisteredComponent(Type type)
        {
            servicesList.Add(type);
        }


        public IRegisteredComponent As<TService>()
        {
            var serviceType = typeof(TService);

            if (!serviceType.IsAssignableFrom(GetComponentType()))
            {
                throw new ArgumentException($"Type {serviceType} is not assignable from {GetComponentType()}");
            }
            if (servicesList.Exists(type => type.Equals(serviceType)))
            {
                return this;
            }

            servicesList.Add(serviceType);

            return this;
        }


        public IRegisteredComponent SingleInstance()
        {
            isSingleInstance = true;
            return this;
        }


        public bool IsService<TService>()
        {
            return servicesList.Exists(type => type.Equals(typeof(TService)));
        }


        public Type GetComponentType()
        {
            return servicesList.First();
        }


        public object GetInstance(IContainer container)
        {
            if (isSingleInstance)
            {
                if (Instance == null)
                {
                    Instance = InstanceCreator.CreateInstance(this, container);
                }
                return Instance;
            }

            return InstanceCreator.CreateInstance(this, container);
        }
    }
}
