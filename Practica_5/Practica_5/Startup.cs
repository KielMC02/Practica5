using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practica_5.Startup))]
namespace Practica_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
