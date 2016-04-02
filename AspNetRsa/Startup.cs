using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetRsa.Startup))]
namespace AspNetRsa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
