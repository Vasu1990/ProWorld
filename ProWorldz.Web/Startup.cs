using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(ProWorldz.Web.Startup))]
namespace ProWorldz.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}