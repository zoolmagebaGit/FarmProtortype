using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmProtortype.Startup))]
namespace FarmProtortype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
