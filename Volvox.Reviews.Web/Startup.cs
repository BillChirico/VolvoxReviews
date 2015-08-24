using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Volvox.Reviews.Web.Startup))]
namespace Volvox.Reviews.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
