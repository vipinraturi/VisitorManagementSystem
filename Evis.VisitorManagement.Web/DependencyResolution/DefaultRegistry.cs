namespace Evis.VisitorManagement.Web.DependencyResolution {
    using Evis.VisitorManagement.Business;
    using Evis.VisitorManagement.Business.Contract;
    using Evis.VisitorManagement.Data.Context;
    using Evis.VisitorManagement.Data.Contract;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IUserRepository>().Use<UserRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IAccountBO>().Use<AccountBO>();
            //need to add all Repository along with particular Interface
        }

        #endregion
    }
}