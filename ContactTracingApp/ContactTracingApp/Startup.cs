using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactTracingApp.Startup))]
namespace ContactTracingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
