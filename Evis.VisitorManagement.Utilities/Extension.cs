using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Utilities
{
    public static class  Extension
    {
        public static IList<T> OrderByName<T>(this IList<T> items, string order, string coloumn)
        {
            // don't try to sort if we have no items
            if (items.Count == 0) return items;
            var propertyInfo = typeof(T).GetProperties()
                                        .Where(p => p.Name == coloumn)
                                        .FirstOrDefault();
            return propertyInfo == null
               ? items
                  : (order.ToUpper() == "ASC"
                  ? items.OrderBy(n => propertyInfo.GetValue(n, null)).ToList()
                  : items.OrderByDescending(n => propertyInfo.GetValue(n, null)).ToList());
        }
    }
}
