using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Evis.eLearning.Business
{
    public class CategoryBO : ICategoryBO
    {
        IUnitOfWork _uof = null;

        public CategoryBO()
        {
            _uof = new UnitOfWork();
        }

        public void AddCategory(Category category)
        {
            var categoryRepository = _uof.GetRepository<Category>();
            categoryRepository.Insert(category);
            
            _uof.Commit();

        }
    }
}
