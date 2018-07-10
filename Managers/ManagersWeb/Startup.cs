using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagersWeb.Startup))]
namespace ManagersWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
