using PlacementManagement.API.Repository;
using PlacementManagement.DataModels;
using PlacementManagement.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PlacementManagement.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual. SimpleInjector
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.RegisterInstance((DatabaseConfig)ConfigurationManager.GetSection("databaseConfig"));
            container.Register(() => new MySqlDBService(
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()));

            // Registering repositories
            container.Register<IRepository<Skill>, SkillRepository>(Lifestyle.Scoped);
            container.Register<IRepository<Program>, ProgramRepository>(Lifestyle.Scoped);
            container.Register<IRepository<QualificationType>, QualificationTypeRepository>(Lifestyle.Scoped);
            container.Register<IRepository<Student>, StudentRepository>(Lifestyle.Scoped);
            container.Register<IStudentRepository<StudentProgram>, StudentProgramRepository>(Lifestyle.Scoped);
            container.Register<IStudentRepository<StudentSkill>, StudentSkillRepository>(Lifestyle.Scoped);
            container.Register<IStudentRepository<StudentQualification>, StudentQualificationRepository>(Lifestyle.Scoped);
            container.Register<ISearchRepository, SearchRepository>(Lifestyle.Scoped);
            

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Response in the form of JSON instead of XML
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
