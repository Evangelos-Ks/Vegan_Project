using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vegan.Web.Startup))]
namespace Vegan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


            // Helps the chat function
            app.MapSignalR();

        }
    }
}
