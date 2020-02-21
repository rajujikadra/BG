using System;
using System.Collections.Generic;
using System.Linq;
using BG_API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using BG_Application.CustomDTO;

[assembly: OwinStartup(typeof(BG_API.Startup))]

namespace BG_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
        private void CreateRolesandUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(EnumTypes.RoleList.ADMIN.ToString()))
            {
                var role = new IdentityRole { Name = EnumTypes.RoleList.ADMIN.ToString() };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(EnumTypes.RoleList.SALESPERSON.ToString()))
            {
                var role = new IdentityRole { Name = EnumTypes.RoleList.SALESPERSON.ToString() };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(EnumTypes.RoleList.BROKER.ToString()))
            {
                var role = new IdentityRole { Name = EnumTypes.RoleList.BROKER.ToString() };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(EnumTypes.RoleList.USER.ToString()))
            {
                var role = new IdentityRole { Name = EnumTypes.RoleList.USER.ToString() };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(EnumTypes.RoleList.SITE.ToString()))
            {
                var role = new IdentityRole { Name = EnumTypes.RoleList.SITE.ToString() };
                roleManager.Create(role);
            }
        }
    }
}
