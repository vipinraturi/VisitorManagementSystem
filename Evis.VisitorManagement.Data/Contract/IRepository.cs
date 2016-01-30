/********************************************************************************
 * File Name    : IRepository.cs
 * Company Name : EVIS
 * Author       : Shambhoo Kumar
 * Created On   : 01/23/2016
 * Description  : 
 *******************************************************************************/
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Data.Contract
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity, bool isDeleted = false);
        void Delete(T entity);
        void DeleteById(int[] ids);
        bool DeleteById(int id);
    }
}
