using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.common.Helpers
{
    /// <summary>
    /// Attribute to specify registration name.
    /// This is used if the class needs to be registered with specific name into the container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class IoCRegistrationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IoCRegistrationAttribute" /> class.
        /// </summary>
        /// <param name="lifetime">The lifetime.</param>
        public IoCRegistrationAttribute(IoCLifetime lifetime)
            : this(null, true, lifetime, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCRegistrationAttribute" /> class.
        /// </summary>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="shouldInterceptMethods">if set to <c>true</c> [should intercept methods].</param>
        public IoCRegistrationAttribute(IoCLifetime lifetime, bool shouldInterceptMethods)
            : this(null, true, lifetime, shouldInterceptMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCRegistrationAttribute" /> class.
        /// </summary>
        /// <param name="shouldInterceptMethods">if set to <c>true</c> [should intercept methods].</param>
        public IoCRegistrationAttribute(bool shouldInterceptMethods)
            : this(null, true, IoCLifetime.Transient, shouldInterceptMethods)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoCRegistrationAttribute" /> class.
        /// </summary>
        /// <param name="namePrefix">The name prefix.</param>
        /// <param name="shouldAppendClassName">if set to <c>true</c> [should append class name].</param>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="shouldInterceptMethods">if set to <c>true</c> [should intercept methods].</param>
        public IoCRegistrationAttribute(string namePrefix, bool shouldAppendClassName, IoCLifetime lifetime, bool shouldInterceptMethods)
        {
            this.NamePrefix = namePrefix;
            this.ShouldAppendClassName = shouldAppendClassName;
            this.Lifetime = lifetime;
            this.ShouldInterceptMethods = shouldInterceptMethods;
        }

        /// <summary>
        /// Gets the lifetime.
        /// </summary>
        /// <value>
        /// The lifetime.
        /// </value>
        public IoCLifetime Lifetime { get; }

        /// <summary>
        /// Gets the value to be prefixed with the class name.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string NamePrefix { get; }

        /// <summary>
        /// Gets a value indicating whether [should append class name].
        /// </summary>
        /// <value>
        /// <c>true</c> if [should append class name]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldAppendClassName { get; }

        /// <summary>
        /// Gets a value indicating whether [should append class name].
        /// </summary>
        /// <value>
        /// <c>true</c> if [should append class name]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldInterceptMethods { get; }
    }
}
