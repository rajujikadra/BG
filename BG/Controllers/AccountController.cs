using BG.Common;
using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BG.Controllers
{
    public class AccountController : BaseController
    {
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (CurrentUser != null && CurrentUser.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Default");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault(), JsonRequestBehavior.AllowGet);
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
                        new Claim("AcessToken", $"{token.access_token}"),
                        //new Claim(ClaimTypes.Role, token.role),
                        //new Claim("AcessToken", $"{token.token_type} {token.access_token}"),
                        // new Claim("Expires_in", "30"),
                    };
                    //var Roles = token.role.Split(',');
                    //foreach (string roleName in Roles)
                    //{
                    //    claims.Add(new Claim(ClaimTypes.Role, roleName.Trim()));
                    //}
                    claims.AddRange(token.role.Split(',').Select(r => new Claim(ClaimTypes.Role, r)));
                    //Session["accessToken"] = token.access_token;
                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                    Request.GetOwinContext().Authentication.SignIn(options, identity);
                    string[] message = new string[] { "success", returnUrl };
                    return Json(new DefaultResponse(HttpStatusCode.OK, message), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new DefaultResponse(HttpStatusCode.NotFound, token.error), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new DefaultResponse(HttpStatusCode.NotFound, "Invalid email or password."));
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            //api/Account/Logout
            if (CurrentUser != null && CurrentUser.Identity.IsAuthenticated)
            {
                string token = ApiHelper.GetToken();
                if (!string.IsNullOrEmpty(token))
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Config.API);
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Config.TokenType, token);
                        var responseTask = client.PostAsync(Config.logout, null);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        string responseContent = await result.Content.ReadAsStringAsync();
                    }
                }
            }
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Login");
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            var DB = new BG_DBEntities();
            ViewBag.Country = DB.CountryMsts.Where(v => v.Active == true).Select(x => new CountryViewModel()
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName
            }).OrderBy(c => c.CountryName).ToList();
            ViewBag.State = new List<SelectListItem>();
            ViewBag.City = new List<SelectListItem>();
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return Json(new DefaultResponse().SetErrorMessages(this).AsDefault(), JsonRequestBehavior.AllowGet);
            try
            {
                var token = ApiHelper.Register(model);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(new DefaultResponse(HttpStatusCode.NotFound, "Invalid email or password."));
            }
        }


        public ActionResult GetStates(int CountryId)
        {
            var DB = new BG_DBEntities();
            var State = DB.StateMsts.Where(x => x.CountryId == CountryId && x.Active == true).Select(y => new StateViewModel()
            {
                StateId = y.StateId,
                StateName = y.StateName
            }).OrderBy(c => c.StateName).ToList();
            return Json(State, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(int StateId)
        {
            var DB = new BG_DBEntities();
            var City = DB.CityMsts.Where(x => x.StateId == StateId && x.Active == true).Select(y => new CityViewModel()
            {
                CityId = y.CityId,
                CityName = y.CityName
            }).OrderBy(c => c.CityName).ToList();
            return Json(City, JsonRequestBehavior.AllowGet);
        }
    }
}