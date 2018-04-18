using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Illium_Forum.Startup))]
namespace Illium_Forum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
