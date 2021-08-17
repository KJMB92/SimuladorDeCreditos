using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Credit.Web.Startup))]
namespace Credit.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
