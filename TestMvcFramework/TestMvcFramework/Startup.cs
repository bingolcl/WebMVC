using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestMvcFramework.Startup))]
namespace TestMvcFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
