using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlacementManagement.Web.Startup))]
namespace PlacementManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
