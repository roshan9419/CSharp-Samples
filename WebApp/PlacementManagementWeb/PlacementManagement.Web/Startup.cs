using log4net;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlacementManagement.Web.Startup))]
namespace PlacementManagement.Web
{
    public partial class Startup
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            _logger.Debug("Auth Configured");
        }
    }
}
