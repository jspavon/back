using generic.app.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Repository
{
    /// <summary>
    /// The repository factory.
    /// </summary>
    /// <seealso cref="Ecp.True.DataAccess.Interfaces.IRepositoryFactory" />
    public class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly IDataContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactory" /> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="businessContext">The business context.</param>
        public RepositoryFactory(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <inheritdoc/>
        public IRepositoryData<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            return new RepositoryData<TEntity>(this.dataContext);
        }
    }
}
