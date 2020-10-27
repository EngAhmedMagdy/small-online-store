using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(small_online_store.Startup))]
namespace small_online_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
