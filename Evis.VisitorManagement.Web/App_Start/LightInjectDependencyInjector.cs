using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.Data.Contract;
using Evis.VisitorManagement.Web.Mapping;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Evis.VisitorManagement.Web.App_Start
{
    public class LightInjectDependencyInjector
    {
        public static void Run()
        {
            SetLightInjectContainer();

            AutoMapperConfiguration.Configure();
        }

        private static void SetLightInjectContainer()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.Register<IUnitOfWork, UnitOfWork>(new PerScopeLifetime());
            container.Register(typeof(Repository<>), typeof(IRepository<>));
            container.Register<IAccountBO, AccountBO>(new PerScopeLifetime());
            container.Register<IVisitorBO, VisitorBO>(new PerScopeLifetime());
            container.Register<IVisitorDetailsBO, VisitorDetailsBO>(new PerScopeLifetime());
            container.EnableMvc();
        }
    }
}