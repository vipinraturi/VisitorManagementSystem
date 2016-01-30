namespace Evis.VisitorManagement.Data.Migrations
{
    using Evis.VisitorManagement.DataProject.Model;
    using Evis.VisitorManagement.DataProject.Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VMSDbContext context)
        {
            //GenerateSalutation(context);
            //GenerateRoles(context);
            //GenerateGender(context);
            //GeneratePrivilage(context);
            //GenerateSystemAdmin(context);
        }

        private static void GenerateGender(VMSDbContext context)
        {
            context.Gender.Add(new Gender { Name = "Male", Description = "Male.", IsActive = true });
            context.Gender.Add(new Gender { Name = "Female", Description = "Female", IsActive = true });
            context.Gender.Add(new Gender { Name = "Other", Description = "Other", IsActive = true });
        }

        //private static void GeneratePrivilage(VMSDbContext context)
        //{
        //    context.Privilage.Add(new Privilage { Name = "Admin", Description = "Admin.", IsActive = true });
        //    context.Privilage.Add(new Privilage { Name = "Supervisor", Description = "Supervisor", IsActive = true });
        //    context.Privilage.Add(new Privilage { Name = "Security", Description = "Security", IsActive = true });
        //}

        //private static void GenerateSalutation(VMSDbContext context)
        //{
        //    context.Salutation.Add(new Salutation { Name = "Ms.", Description = "Ms.", IsActive = true });
        //    context.Salutation.Add(new Salutation { Name = "Mr.", Description = "Mr.", IsActive = true });
        //    context.Salutation.Add(new Salutation { Name = "Dr.", Description = "Dr.", IsActive = true });
        //}

        private static void GenerateRoles(VMSDbContext context)
        {
            context.Roles.Add(new ApplicationRole { Name = "Admin", Description = "Admin" });
            context.Roles.Add(new ApplicationRole { Name = "Supervisor", Description = "Supervisor" });
            context.Roles.Add(new ApplicationRole { Name = "Security", Description = "Security" });
        }

        private void GenerateSystemAdmin(VMSDbContext context)
        {
            var systemAdminrole = context.Roles.Add(new ApplicationRole { Name = "SystemAdmin", Description = "System Admin" });

            var newSystemAdminUser = new ApplicationUser
            {
                FirstName = "System",
                LastName = "Admin",
                Email = "systemadmin@evisuae.com",
                PhoneNumber = "1234567890",
                UserName = "systemadmin@rebuild.com",
                GenderId =  1,
                SecurityStamp = System.Guid.NewGuid().ToString()
            };

            var passwordHash = new Microsoft.AspNet.Identity.PasswordHasher();
            var hashedPassword = passwordHash.HashPassword("Evis@123");
            newSystemAdminUser.PasswordHash = hashedPassword;

            var systemAdminUser = context.Users.Add(newSystemAdminUser);

            systemAdminUser.Roles.Add(
                new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                {
                    UserId = systemAdminUser.Id,
                    RoleId = systemAdminrole.Id
                });

            context.Users.AddOrUpdate(systemAdminUser);
        }
    }
}
