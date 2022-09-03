using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoleBased.Startup))]
namespace RoleBased
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
