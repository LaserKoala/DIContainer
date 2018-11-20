using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Container.Interface
{
    public interface IContainer
    {
        IRegisteredComponent RegisterType<TComponent>();
        ResolveType Resolve<ResolveType>();
    }
}
