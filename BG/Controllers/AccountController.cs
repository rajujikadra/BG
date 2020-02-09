using BG.Helper;
using BG.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BG.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        // POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    return View();
        //}
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault());
            try
            {
                var token = ApiHelper.Login(model);
                if (!string.IsNullOrEmpty(token.access_token))
                {
                    var options = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(120) //int.Parse(token.expires_in)//2419199
                    };
                    if (string.IsNullOrEmpty(token.userName))
                        token.userName = model.UserName.Trim();
                    if (string.IsNullOrEmpty(token.email))
                        token.email = model.UserName.Trim();
                    var claims = new List<Claim>()
                    {
                        //new Claim(ClaimTypes.NameIdentifier, token.id),
                        new Claim("currentTime", DateTime.Now.ToString()),
                        new Claim(ClaimTypes.Name, token.userName),
                        new Claim(ClaimTypes.Email, token.email),
                        new Claim("AcessToken", $"{token.token_type} {token.access_token}"),
                        // new Claim("Expires_in", "30"),
                    };

                    //claims.AddRange(token.role.Split(',').Select(r => new Claim(ClaimTypes.Role, r)));
                    //Session["accessToken"] = token.access_token;
                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                    Request.GetOwinContext().Authentication.SignIn(options, identity);
                    string[] message = new string[] { "success", returnUrl };
                    return Json(new DefaultResponse(HttpStatusCode.OK, message));
                }
                else
                {
                    return Json(new DefaultResponse(HttpStatusCode.NotFound, "Invalid email or password."));
                }
            }
            catch (Exception ex)
            {
                return Json(new DefaultResponse(HttpStatusCode.NotFound, "Invalid email or password."));
            }
        }
    }
}