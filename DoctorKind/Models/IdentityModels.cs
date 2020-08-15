using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using DoctorKind.Models.DbEntities;
using System.Collections.Generic;
namespace DoctorKind.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; }
        public string OTP { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DoctorKind", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ApplicationInitializer());
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppImage> Images { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class ApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create Admin Role
            string[] roleNames = { "Admin", "Doctor", "Patient", "SuperAdmin", "Employee", "FOS", "Doctor", "Pathlogy", "Pharmacy", "Clinic" };
            IdentityResult roleResult;
            foreach (string roleName in roleNames)
            {// Check to see if Role Exists, if not create it
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                    if (roleName == "SuperAdmin")
                    {
                        var store = new UserStore<ApplicationUser>(context);
                        var manager = new UserManager<ApplicationUser>(store);
                        var user = new ApplicationUser { UserName = "admin" };
                        manager.Create(user, "DoctorKind@123");
                        manager.AddToRole(user.Id, "SuperAdmin");
                    }
                }
            }

            IList<AppointmentType> appTypes = new List<AppointmentType>();
            appTypes.Add(new AppointmentType { IsActive = true, Name = "Video" });
            appTypes.Add(new AppointmentType { IsActive = true, Name = "Audio" });
            appTypes.Add(new AppointmentType { IsActive = true, Name = "Chat" });

            foreach (AppointmentType appType in appTypes)
                context.AppointmentTypes.Add(appType);
            base.Seed(context);
        }
    }
}