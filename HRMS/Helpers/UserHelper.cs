using HRMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using HRMS.Services;

namespace HRMS.Helpers
{
    public class UserHelper 
    {
        public static ApplicationUser LoggedInUser
        {
            get
            {
                ApplicationUser user = null;
                IdentityRole role = null;
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    if (HttpContext.Current.Session["LoggedInUser"] != null)
                    {
                        user = (ApplicationUser)HttpContext.Current.Session["LoggedInUser"];
                    }
                    else
                    {
                        var db = new ApplicationDbContext();
                        var userService = new UserService(db);
      

                        var userGuid = HttpContext.Current.User.Identity.GetUserId();
                        user = userService.GetUser(userGuid);
                        //store the role to avoid database hit
                        if (user!=null && user.Roles.FirstOrDefault() != null)
                        {
                            var roleId = user.Roles.FirstOrDefault().RoleId;
                            role = userService.GetRole(roleId);
                        }

                        db.Dispose();
                        db = null;
                        HttpContext.Current.Session["LoggedInUserRole"] = role;
                        HttpContext.Current.Session["LoggedInUser"] = user;
                    }
                }
                return user;
            }
            set { HttpContext.Current.Session["LoggedInUser"] = value; }
        }

        public static string LoggedInUserId
        {
            get
            {
                string id = "";
                if (LoggedInUser != null)
                {
                    id = LoggedInUser.Id;
                }
                return id;
            }
        }
        public static IdentityRole LoggedInUserRole
        {
            get
            {
                IdentityRole role = null;
                if (HttpContext.Current.Session["LoggedInUserRole"] != null)
                {
                    role = (IdentityRole)HttpContext.Current.Session["LoggedInUserRole"];
                }
                else
                {
                    //if (LoggedInUser != null)
                    //{
                    //    var db = new ApplicationDbContext();
                    //    var userService = new UserService(db);
                    //    using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)))
                    //    {
                    //        var rolesForUser =  userManager.getR
                    //      //  role = rolesForUser.FirstOrDefault();

                    //       // rolesForUser now has a list role classes.
                    //    };
                    //    db.Dispose();
                    //    db = null;
                    //    HttpContext.Current.Session["LoggedInUserRole"] = role;
                    //}
                }
                return role;
            }
            set { HttpContext.Current.Session["LoggedInUserRole"] = value; }
        }

        public static string LoggedInUserRoleId
        {
            get
            {
                var id = string.Empty;
                if (LoggedInUserRole != null)
                {
                    id = LoggedInUserRole.Id;
                }
                return id;
            }
        }

        public static string LoggedInUserRoleName
        {
            get
            {
                var name = string.Empty;
                if (LoggedInUserRole != null)
                {
                    name = LoggedInUserRole.Name;
                }
                return name;
            }
        }

    }
}