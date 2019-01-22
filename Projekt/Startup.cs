using Microsoft.Owin;
using Owin;
using Projekt.Models;

[assembly: OwinStartupAttribute(typeof(Projekt.Startup))]
namespace Projekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
