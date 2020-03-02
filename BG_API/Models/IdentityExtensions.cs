using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BG_API.Models
{
    public static class IdentityExtensions
    {
        public static string GetEmailAdress(this IIdentity identity)
        {
            var userId = identity.GetUserId();
            using (var context = new BG_Application.Data.BG_DBEntities())
            {
                var user = context.AspNetUsers.FirstOrDefault(u => u.Id == userId);
                return user.Email;
            }
        }
    }
}