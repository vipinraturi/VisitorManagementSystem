using Evis.VisitorManagement.Web.App_Start;
using Evis.VisitorManagement.Web.DependencyResolution;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using StructureMap;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace Evis.VisitorManagement.Web.App_Start 
{
    
	public static class StructuremapMvc {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion
		
		#region Public Methods and Operators
		
		public static void End() {
            StructureMapDependencyScope.Dispose();
        }
		
        public static void Start() {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion
    }
}