using System;
using CLabanowski.Infrastructure;
using CLabanowski.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(CLabanowski.Startup))]
namespace CLabanowski
{
    public class Startup
    {
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // this is the same as before
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/auth/login")
            });

            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(new CLabanowskiContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<IdentityUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }
    }
}
