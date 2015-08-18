using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using CLabanowski.Models.Interfaces;
using CLabanowski.Models.Repositories;
using Ninject;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace CLabanowski.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IBlogPostRepository>().To<EFBlogPostRepository>();
            _kernel.Bind<IPortfolioProjectRepository>().To<EFPortfolioProjectRepository>();
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}