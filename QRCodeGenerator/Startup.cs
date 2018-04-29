using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QRCodeGenerator.Startup))]
namespace QRCodeGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
