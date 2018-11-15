using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UmbitiousCalculator.Startup))]
namespace UmbitiousCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
