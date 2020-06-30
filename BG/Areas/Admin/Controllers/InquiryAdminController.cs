using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BG.Common;
using BG.Helper;
using BG.Models;
using BG_Application.CustomDTO;
using BG_Application.Data;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BG.Areas.Admin.Controllers
{
    [Authorize]
    [RouteArea("Admin", AreaPrefix = "admin")]

    public class InquiryAdminController : Controller
    {
        [Route("inquiry")]
        // GET: Admin/InquiryAdmin
        public ActionResult Index()
        {
            var DB = new BG_DBEntities();
            var inquirys = new List<InquiryViewModel>();
            string CurrentUserID = DB.AspNetUsers.FirstOrDefault(x => x.Email == User.Identity.Name).Id;
            if (User.IsInRole(EnumTypes.RoleList.ADMIN.ToString()))
            {
                inquirys = DB.InquiryMsts.Select(x => new InquiryViewModel()
                {
                    UserName = x.AspNetUser.FirstName + " " + x.AspNetUser.LastName,
                    City = x.CityMst.CityName,
                    State = x.StateMst.StateName,
                    Country = x.CountryMst.CountryName,
                    Comments = x.Comments,
                    CompanyAddress = x.CompanyAddress,
                    CompanyName = x.CompanyName,
                    InquiryName = x.InquiryName,
                    Type = x.Type,
                    UserId = x.UserId,
                    IsResolve = x.IsResolve
                }).ToList();
            }
            else if (User.IsInRole(EnumTypes.RoleList.SALESPERSON.ToString()))
            {
                inquirys = (from I in DB.InquiryMsts
                            join S in DB.AssignSalesPersonMsts on I.UserId equals S.CustomerID
                            where S.SalesPersonID == CurrentUserID
                            select new InquiryViewModel()
                            {
                                UserName = I.AspNetUser.FirstName + " " + I.AspNetUser.LastName,
                                City = I.CityMst.CityName,
                                State = I.StateMst.StateName,
                                Country = I.CountryMst.CountryName,
                                Comments = I.Comments,
                                CompanyAddress = I.CompanyAddress,
                                CompanyName = I.CompanyName,
                                InquiryName = I.InquiryName,
                                Type = I.Type,
                                UserId = I.UserId,
                                IsResolve = I.IsResolve
                            }).ToList();
            }
            return View(inquirys);
        }
    }
}