using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScraperApplication.Startup))]
namespace ScraperApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
