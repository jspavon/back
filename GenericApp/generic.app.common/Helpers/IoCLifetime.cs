using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.common.Helpers
{
    /// <summary>
    /// Contains the different lifetime that is supported. By default Transient lifetime is used.
    /// </summary>
    public enum IoCLifetime
    {
        /// <summary>
        /// The transient
        /// </summary>
        Transient,

        /// <summary>
        /// The hierarchical
        /// </summary>
        Hierarchical,

        /// <summary>
        /// The container controlled
        /// </summary>
        ContainerControlled,
    }
}
