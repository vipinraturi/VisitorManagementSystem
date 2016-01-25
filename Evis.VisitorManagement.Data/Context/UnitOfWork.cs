using Evis.VisitorManagement.Data.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Evis.VisitorManagement.Data
{
    /// <summary>
    /// Represents a Unit of work for EDIS DbContext
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Factory to create repository
        /// </summary>
        RepositoryFactory _repoFactory = null;

        /// <summary>
        /// Constructor of UnitOfWork
        /// </summary>
        /// <param name="dbContext">DbContext to use</param>
        public UnitOfWork(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }
            Context = dbContext;
            _repoFactory = new RepositoryFactory(dbContext);
        }

        public UnitOfWork()
        { 
            
        }

        /// <summary>
        /// Gets current DbContext
        /// </summary>
        public DbContext Context { get; set; }

        /// <summary>
        /// Gets the instance of RepositoryFactory
        /// </summary>
        public RepositoryFactory GetRepositoryFactory { get { return _repoFactory; } }

        /// <summary>
        /// Commits all changes made to this context
        /// </summary>
        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }
       
       
        /// <summary>
        /// Gets a repository by type
        /// </summary>
        /// <typeparam name="T">Type of repository</typeparam>
        /// <returns></returns>
        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            RepositoryFactory obj = new RepositoryFactory(new LearningDataEntities());
            return obj.GetRepository<T>();
        }
        
        /// <summary>
        /// Releases all resources claimed by this object
        /// </summary>
        void IDisposable.Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
