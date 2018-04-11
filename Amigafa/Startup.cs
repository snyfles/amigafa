using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amigafa.Startup))]
namespace Amigafa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
