using Evis.VisitorManagement.DataProject.Model;
/********************************************************************************
 * File Name    : LearningDataEntities.cs
 * Company Name : EVIS
 * Author       : Vipin Raturi
 * Created On   : 01/20/2016
 * Description  : 
 *******************************************************************************/
using System;
using System.Data.Entity;

namespace Evis.VisitorManagement.Data
{
    public partial class LearningDataEntities : DbContext
    {
        public LearningDataEntities()
            : base("name=LearningDataEntities")
        {
            Database.SetInitializer(new LearningDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Category> categories { get; set; }
    }
}
