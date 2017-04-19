using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SF.Web.Startup))]
namespace SF.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
