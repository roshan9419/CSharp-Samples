using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthTestWebApp.Startup))]
namespace AuthTestWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
