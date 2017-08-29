using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<SystemText> SystemTexts { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.JobPost> JobPosts { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Leave> Leaves { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Organization> Organizations { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Asset> Assets { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.ClaimRequest> Claims { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.SalaryStack> SalaryStacks { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.PersonalInfo> PersonalInfoes { get; set; }

        public System.Data.Entity.DbSet<HRMS.Models.Address> Addresses { get; set; }
    }


    public sealed class RoleNames
    {
        //Role for all acess 
        public const string SystemAdmin = "System Admin";
        //Any manager for APROVAL
        public const string Manager = "Manager";
        //Mid lavel leader
        public const string Leader = "Leader";
        //Normal all employee
        public const string Consultant = "Consulatent";

    }

}