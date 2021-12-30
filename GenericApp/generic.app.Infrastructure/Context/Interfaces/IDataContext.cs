using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Context
{
    /// <summary>
    /// The data context for data store.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>The db set.</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity entry.</returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Saves the context asynchronous.
        /// </summary>
        /// <returns>
        /// Number of rows effected.
        /// </returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Saves the context asynchronous.
        /// </summary>
        /// <returns>
        /// Number of rows effected.
        /// </returns>
        int Save();

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void RollBack();
    }
}
