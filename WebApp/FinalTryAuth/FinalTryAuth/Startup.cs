using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalTryAuth.Startup))]
namespace FinalTryAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
