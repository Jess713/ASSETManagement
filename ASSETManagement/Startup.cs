using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASSETManagement.Startup))]
namespace ASSETManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
