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
    public class LearningDBInitializer : DropCreateDatabaseIfModelChanges<LearningDataEntities>
    {
        public override void InitializeDatabase(LearningDataEntities context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(LearningDataEntities context)
        {
            base.Seed(context);
        }
    }
}
