/********************************************************************************
 * File Name    : CategoryRepository.cs
 * Company Name : EVIS
 * Author       : Shambhoo Kumar
 * Created On   : 01/23/2016
 * Description  : Insert/Delete/Update records for Category
 *******************************************************************************/


//using Evis.eLearning.Infrastructure;

using Evis.VisitorManagement.Data.Contract;
using Evis.VisitorManagement.DataProject.Model;

namespace Evis.VisitorManagement.Data.Context
{
    public class CategoryRepository : Repository<Evis.VisitorManagement.DataProject.Model.Category>, ICategoryRepository
    {
        
    }
}
