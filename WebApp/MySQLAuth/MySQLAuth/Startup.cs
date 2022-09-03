using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySQLAuth.Startup))]
namespace MySQLAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
