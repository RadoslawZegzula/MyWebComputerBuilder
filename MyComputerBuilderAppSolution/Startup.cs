using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyOnlineShop.Startup))]
namespace MyOnlineShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
