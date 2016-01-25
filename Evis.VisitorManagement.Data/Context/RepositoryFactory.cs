using Evis.VisitorManagement.Data.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Evis.VisitorManagement.Data
{
    /// <summary>
    /// Factory class for creating a repository
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// Constructor for RepositoryFactory class
        /// </summary>
        /// <param name="dbContext">DbContext to be used</param>
        public RepositoryFactory(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }
            Context = dbContext;
        }

        /// <summary>
        /// Returns current DbContext
        /// </summary>
        public DbContext Context { get; set; }

        /// <summary>
        /// Gets a repository instace for asked type
        /// </summary>
        /// <typeparam name="T">Type of the repository</typeparam>
        /// <returns></returns>
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>();
        }
    }
}
