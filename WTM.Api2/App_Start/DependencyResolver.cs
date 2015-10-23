using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace WTM.Api2
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly LightInject.IServiceContainer serviceContainer;

        public DependencyResolver(LightInject.IServiceContainer serviceContainer)
        {
            if (serviceContainer == null)
            {
                throw new ArgumentNullException("container");
            }

            this.serviceContainer = serviceContainer;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.serviceContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return this.serviceContainer.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceContainer.GetAllInstances(serviceType);
        }
    }
}
