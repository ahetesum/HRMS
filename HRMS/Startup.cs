using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRMS.Startup))]
namespace HRMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
