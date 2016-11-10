using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shypp.Startup))]
namespace Shypp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
