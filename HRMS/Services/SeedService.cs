using HRMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Services
{
    public class SeedService : BaseService
    {
        #region Declaration
        private readonly UserService _userService;

        public SeedService(ApplicationDbContext db)
        {
            this.db = db;
            _userService = new UserService(db);

        }
        #endregion

        // This is strictly for test purpose.
        public TimeSpan Seed()
        {
            var starttime = DateTime.Now;

            // Seed base data
            SeedRoles();

            db.SaveChanges();
            var endTime = DateTime.Now;
            return endTime - starttime;
        }


        private void SeedRoles()
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(db));

            //System Admin
            var systemAdmin = roleManager.FindByName(RoleNames.SystemAdmin);
            if (systemAdmin == null)
            {
                systemAdmin = new IdentityRole(RoleNames.SystemAdmin);
                roleManager.Create(systemAdmin);
            }
            //Manager
            var manager = roleManager.FindByName(RoleNames.Manager);
            if (manager == null)
            {
                manager = new IdentityRole(RoleNames.Manager);
                roleManager.Create(manager);
            }
            //Sales
            var sales = roleManager.FindByName(RoleNames.Leader);
            if (sales == null)
            {
                sales = new IdentityRole(RoleNames.Leader);
                roleManager.Create(sales);
            }
            //Marketing
            var marketing = roleManager.FindByName(RoleNames.Consultant);
            if (marketing == null)
            {
                marketing = new IdentityRole(RoleNames.Consultant);
                roleManager.Create(marketing);
            }

        }

        //private void SeedOrganizations()
        //{
        //    var organization = db.Organizations.FirstOrDefault();
        //    if (organization == null)
        //    {
        //        organization = new Organization
        //        {
        //            Name = "Infinize",
        //            WebSite = "www.infinize.com",
        //            Email = "contact@infinize.com",
        //            ModifiedDate = DateTime.Now,
        //            Phone1 = "+919970896816",
        //            Phone2 = "+919916708968",
        //            AddressLine1 = "#18, 2nd Main, 6th Cross",
        //            AddressLine2 = "Mahabazar Road",
        //            City = "Bangalore",
        //            Pin = "560054",
        //            State = "Karnataka",
        //            //Account Details
        //            BankName = "SBI Bank",
        //            BankBranch = "Dollars Colony Branch",
        //            BankAcountNumber = "00345678934567",
        //            BankIIFC = "SBI001234",
        //            BankMICR = "SBI980021",
        //            Pan = "APJ0986VY",
        //            Vat = "5.5%",
        //            Tin = "234234234",
        //        };
        //        db.OrganizationInfoes.Add(organization);
        //    }
        //}


        //private void SeedUsers()
        //{
        //    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        //    //System Admin
        //    var email = "admin@infinize.com";
        //    var user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FirstName = "Admin",
        //        LastName = "Nilu",
        //        EmailConfirmed = true,
        //    };
        //    var result = userManager.Create(user, "Admin123$");
        //    if (result.Succeeded)
        //    {
        //        var rolesForUser = userManager.GetRoles(user.Id);
        //        if (!rolesForUser.Contains(RoleNames.SystemAdmin))
        //        {
        //            userManager.AddToRole(user.Id, RoleNames.SystemAdmin);
        //        }
        //    }
        //    // Manager
        //    email = "manager@infinize.com";
        //    user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FirstName = "Manager",
        //        LastName = "Jimmy",
        //        EmailConfirmed = true,
        //    };
        //    result = userManager.Create(user, "Admin123$");
        //    if (result.Succeeded)
        //    {
        //        var rolesForUser = userManager.GetRoles(user.Id);
        //        if (!rolesForUser.Contains(RoleNames.Manager))
        //        {
        //            userManager.AddToRole(user.Id, RoleNames.Manager);
        //        }
        //    }

        //    // Sales
        //    email = "sales@infinize.com";
        //    user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FirstName = "sales",
        //        LastName = "Puroshottam",
        //        EmailConfirmed = true,
        //    };

        //    result = userManager.Create(user, "Admin123$");
        //    if (result.Succeeded)
        //    {
        //        var rolesForUser = userManager.GetRoles(user.Id);
        //        if (!rolesForUser.Contains(RoleNames.Sales))
        //        {
        //            userManager.AddToRole(user.Id, RoleNames.Sales);
        //        }
        //    }

        //    // Marketing
        //    email = "marketing@infinize.com";
        //    user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FirstName = "Support",
        //        LastName = "Sarif",
        //        EmailConfirmed = true,
        //    };

        //    result = userManager.Create(user, "Admin123$");
        //    if (result.Succeeded)
        //    {
        //        var rolesForUser = userManager.GetRoles(user.Id);
        //        if (!rolesForUser.Contains(RoleNames.Support))
        //        {
        //            userManager.AddToRole(user.Id, RoleNames.Support);
        //        }
        //    }
        //    // Account
        //    email = "ahetesum@infinize.com";
        //    user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FirstName = "Account",
        //        LastName = "ahetesum",
        //        EmailConfirmed = true,
        //    };
        //    result = userManager.Create(user, "Admin123$");
        //    if (result.Succeeded)
        //    {
        //        var rolesForUser = userManager.GetRoles(user.Id);
        //        if (!rolesForUser.Contains(RoleNames.Accountant))
        //        {
        //            userManager.AddToRole(user.Id, RoleNames.Accountant);
        //        }
        //    }


        //}






    }


}
