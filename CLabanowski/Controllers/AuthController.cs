using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using CLabanowski.Infrastructure;
using CLabanowski.Models;
using CLabanowski.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CLabanowski.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController() : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Auth
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager.Find(model.Email, model.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();

            ////CHANGE WHEN YOU GO TO PRODUCTION!!!
            //if (model.Email == "admin@admin.com" && model.Password == "password")
            //{
            //    //once the user is authenticated, user info is passed to the cookie
            //    //using the ClaimsIdentity object
            //    var identity = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.Name, "Charles"),
            //        new Claim(ClaimTypes.Email, "clabanow@gmail.com"),
            //        new Claim(ClaimTypes.Country, "USA"),
            //    },
            //        "ApplicationCookie");

            //    var ctx = Request.GetOwinContext();
            //    var authManager = ctx.Authentication;

            //    //set the auth cookie on the client
            //    authManager.SignIn(identity);

            //    //redirect the user to the url they were attempting 
            //    //to access before they were forced to login
            //    return Redirect(GetRedirectUrl(model.ReturnUrl));
            //}

            //ModelState.AddModelError("", "Invalid email or password");
            //return View();
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            return authManager;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {
            //get the IAuthMgr instance from OWIN context
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            //pass in cookie name so the mgr knows what to remove
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new IdentityUser
            {
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        private async Task SignIn(IdentityUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            //this is one way to add extra info to a user cookie
            //identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));

            GetAuthenticationManager().SignIn(identity);
        }
    }
}