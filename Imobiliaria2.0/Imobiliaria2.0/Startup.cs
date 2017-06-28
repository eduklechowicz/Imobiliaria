using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Imobiliaria2._0.Startup))]
namespace Imobiliaria2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
