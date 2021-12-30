using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Context
{
    /// <summary>
    /// The connection factory to host connection details.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets a value indicating whether this instance is ready.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ready; otherwise, <c>false</c>.
        /// </value>
        bool IsReady { get; }

        /// <summary>
        /// Gets the SQL connection configuration.
        /// </summary>
        /// <value>
        /// The SQL connection configuration.
        /// </value>
        string SqlConnectionConfig { get; }

        /// <summary>
        /// Gets the no SQL connection string.
        /// </summary>
        /// <value>
        /// The no SQL connection string.
        /// </value>
        string NoSqlConnectionString { get; }

        /// <summary>
        /// Initializes the specified storage connection string.
        /// </summary>
        /// <param name="storageConnectionString">The storage connection string.</param>
        void SetupStorageConnection(string storageConnectionString);

        /// <summary>
        /// Setups the SQL configuration.
        /// </summary>
        /// <param name="sqlConnectionConfig">The SQL connection configuration.</param>
        void SetupSqlConfig(string sqlConnectionConfig);
    }
}
