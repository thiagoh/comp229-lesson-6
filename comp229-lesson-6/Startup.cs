using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

// required for OWIN Startup
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(comp229_lesson_6.Startup))]

namespace comp229_lesson_6 {

    public class Startup {

        public void Configuration(IAppBuilder app) {

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var authOpts =  new CookieAuthenticationOptions();
            authOpts.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            authOpts.LoginPath = new PathString("/Login.aspx");

            app.UseCookieAuthentication(authOpts);
        }
    }
}
