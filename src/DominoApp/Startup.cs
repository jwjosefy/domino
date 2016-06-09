using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DominoApp.Startup))]
namespace DominoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
