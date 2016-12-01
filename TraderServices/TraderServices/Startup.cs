using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TraderServices.Startup))]
namespace TraderServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
