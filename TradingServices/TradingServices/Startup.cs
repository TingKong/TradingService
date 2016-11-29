using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradingServices.Startup))]
namespace TradingServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
