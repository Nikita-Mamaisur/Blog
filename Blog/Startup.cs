using Blog.DataAccess.Context;
using Blog.DataAccess.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Blog.Startup))]

namespace Blog
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new BlogContext());

            app.CreatePerOwinContext<UserManager<User>>((options, context) =>
            {
                var dbContext = context.Get<BlogContext>();
                var userStore = new UserStore<User>(dbContext);
                var userManager = new UserManager<User>(userStore)
                {
                    PasswordValidator = new PasswordValidator()
                    {
                        RequiredLength = 6,
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false
                    }
                };

                userManager.UserValidator = new UserValidator<User>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                return userManager;
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/account/login")
            });
        }
    }
}
