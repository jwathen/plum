using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Plum.Startup))]
namespace Plum
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}