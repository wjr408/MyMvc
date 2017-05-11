using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyUI.Startup))]
namespace MyUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
