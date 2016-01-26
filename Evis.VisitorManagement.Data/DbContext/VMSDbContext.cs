using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
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
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Salutation> Salutation { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
    }
}
