using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Container.Interface
{
    public interface IRegisteredComponent
    {
        IRegisteredComponent As<TService>();
        IRegisteredComponent SingleInstance();
        object GetInstance(IContainer container);
        Type GetComponentType();
        bool IsService<TComponent>();
    }
}
