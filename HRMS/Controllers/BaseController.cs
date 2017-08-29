using HRMS.Helpers;
using HRMS.Models;
using HRMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db;

        public BaseController()
        {
            db = new ApplicationDbContext();

            var userService = new UserService(db);
            //ViewBag.MessagesForLoggedInUser = new MessageService(db).GetMessagesForLoggedInUser();
            if (UserHelper.LoggedInUser == null && System.Web.HttpContext.Current.Request.IsAuthenticated)
            {
                var userName = System.Web.HttpContext.Current.User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                UserHelper.LoggedInUser = user;


                if (user != null && user.Roles.FirstOrDefault() != null)
                {
                    var role = userService.GetRole(user.Roles.FirstOrDefault().RoleId);
                    UserHelper.LoggedInUserRole = role;
                }
                else
                {
                    // log out the user, something is wrong.
                    userService.LogOff();
                }
            }
        }


    }
}