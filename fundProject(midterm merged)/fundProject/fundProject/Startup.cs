using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(fundProject.Startup))]

namespace fundProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            app.MapSignalR();
        }
    }
}
