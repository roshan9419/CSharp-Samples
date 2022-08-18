using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAuthIndividual.Startup))]
namespace MVCAuthIndividual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
