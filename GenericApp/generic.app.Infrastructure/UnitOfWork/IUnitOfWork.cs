
using generic.app.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Interface IUnitOfWork
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        
        new void Dispose();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        
        int Save();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        
        Task<int> SaveAsync();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        
        void Rollback();

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>
        /// The repository.
        /// </returns>
        IRepositoryData<TEntity> CreateRepository<TEntity>()
            where TEntity : class;
    }
}
