using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagersWebApp.Startup))]
namespace ManagersWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
