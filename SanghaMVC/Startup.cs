using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SanghaMVC.Startup))]
namespace SanghaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
