using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(WaitlistApp.Startup))]
namespace WaitlistApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}