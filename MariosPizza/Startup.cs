using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MariosPizza.Startup))]
namespace MariosPizza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
