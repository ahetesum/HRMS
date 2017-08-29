using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web.Security;
using HRMS.Models;

namespace HRMS.Services
{
    public class UserService : BaseService
    {
        #region Declaration

        private readonly ApplicationUserManager _userManager =
            HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        #endregion

        public ApplicationUser LoggedInUser
        {
            get
            {
                ApplicationUser user = null;
                if (HttpContext.Current.Session["LoggedInUser"] != null)
                {
                    user = (ApplicationUser)HttpContext.Current.Session["LoggedInUser"];
                }
                else
                {
                    if (HttpContext.Current.Request.IsAuthenticated)
                    {
                        var userGuid = HttpContext.Current.User.Identity.GetUserId();
                        user = GetUser(userGuid);
                        HttpContext.Current.Session["LoggedInUser"] = user;
                    }
                }
                return user;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public ApplicationUser GetUser(string userGuid)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == userGuid);
            return user;
        }

        //public EditUserViewModel GetUserRegisterViewModel(int id)
        //{
        //    var user = GetUser(id);
        //    return new EditUserViewModel(user, GetRolesDropDown());
        //}


        public void DeleteUser(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id.ToString());

            if (user != null)
            {
                db.SaveChanges();
            }
        }


        public ApplicationUser GetUserByUserName(string userName)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }



        public List<ApplicationUser> GetUsers()
        {
            var users = db.Users.ToList();
            return users;
        }


        public IdentityRole GetUserRole(string userGuid)
        {
            return GetUserRole(GetUser(userGuid));
        }

        public IdentityRole GetUserRole(ApplicationUser user)
        {
            IdentityRole role = null;

            if (user != null)
            {
                var userRole = user.Roles.FirstOrDefault();
                if (userRole != null)
                {
                    var roleId = userRole.RoleId;
                    role = db.Roles.FirstOrDefault(x => x.Id == roleId);
                }
            }
            return role;
        }

        public IdentityRole GetRole(string RoleId)
        {
            return db.Roles.FirstOrDefault(x => x.Id == RoleId);
        }

        public List<ApplicationUser> GetUsersByRoleName(string roleName)
        {
            var role = db.Roles.FirstOrDefault(x => x.Name == roleName);
            if (role != null)
            {
                var roleId = role.Id;
                return db.Users.Where(x => x.Roles.Any(r => r.RoleId == roleId)).ToList();
            }
            return new List<ApplicationUser>();
        }

        public bool LogOff()
        {
            AuthenticationManager.SignOut();
            FormsAuthentication.SignOut();
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            HttpContext.Current.Session.Abandon();

            HttpContext.Current.Session["LoggedInUser"] = null;
            HttpContext.Current.Session["LoggedInUserRole"] = null;

            return true;
        }

    }
}