using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YLFR.Startup))]
namespace YLFR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
