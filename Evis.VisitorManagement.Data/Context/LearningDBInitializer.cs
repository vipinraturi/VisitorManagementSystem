/********************************************************************************
 * File Name    : LearningDBInitializer.cs
 * Company Name : EVIS
 * Author       : Vipin Raturi
 * Created On   : 01/20/2016
 * Description  : 
 *******************************************************************************/
using System.Data.Entity;

namespace Evis.VisitorManagement.Data
{
    public class LearningDBInitializer : DropCreateDatabaseIfModelChanges<VMSDbContext>
    {
        public override void InitializeDatabase(VMSDbContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(VMSDbContext context)
        {
            base.Seed(context);
        }
    }
}
