using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crud.WebUI.Startup))]
namespace Crud.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
