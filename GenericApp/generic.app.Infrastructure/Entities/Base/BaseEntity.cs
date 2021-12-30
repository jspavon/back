using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Entities.Base
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>        
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the creation user.
        /// </summary>
        /// <value>The creation user.</value>        
        public string CreationUser { get; set; }

        /// <summary>
        /// Gets or sets the modification date.
        /// </summary>
        /// <value>The modification date.</value>        
        public DateTime? ModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the modification user.
        /// </summary>
        /// <value>The modification user.</value>        
        public string ModificationUser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseEntity"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>        
        public bool Deleted { get; set; }
    }
}
