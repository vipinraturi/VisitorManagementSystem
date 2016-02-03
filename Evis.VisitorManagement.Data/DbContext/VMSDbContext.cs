using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
using Microsoft.AspNet.Identity.EntityFramework;
/********************************************************************************
 * File Name    : VMSDbContext.cs
 * Company Name : EVIS
 * Author       : Vipin Raturi
 * Created On   : 01/20/2016
 * Description  : 
 *******************************************************************************/
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Evis.VisitorManagement.Data
{
    public partial class VMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public VMSDbContext()
            : base("VMSDbContext")
        {
            Database.SetInitializer<VMSDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Category> Category { get; set; }
        //public DbSet<Salutation> Salutation { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Building> Building { get; set; }

        public DbSet<BuildingGate> BuildingGate { get; set; }

        public DbSet<BuildingLocation> BuildingLocation { get; set; }

        public DbSet<Company> Company { get; set; }
    }
}
