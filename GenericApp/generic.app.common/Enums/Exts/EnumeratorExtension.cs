using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace generic.app.common.Enums.Exts
{
    /// <summary>
    /// Class EnumeratorExtension.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />    
    [ExcludeFromCodeCoverage]
    public class EnumeratorExtensionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumeratorExtension" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        
        public EnumeratorExtensionAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        
        public string Value { get; }
    }

    /// <summary>
    /// Class EnumeratorExtensionAttribute.
    /// </summary>    
    [ExcludeFromCodeCoverage]
    public static class EnumeratorExtension
    {
        /// <summary>
        /// Converts to stringattribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>        
        public static string ToStringAttribute(this Enum value)
        {
            var stringValues = new Hashtable();

            string output = null;
            var type = value.GetType();

            //Comprueba si ya existe la búsqueda en caché
            if (stringValues.ContainsKey(value))
            {
                var stringValueAttribute = (EnumeratorExtensionAttribute)stringValues[value];
                if (stringValueAttribute != null)
                    output = stringValueAttribute.Value;
            }
            else
            {
                //Buscar el ToStringAttribute en los atributos personalizados
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                var attrs = (EnumeratorExtensionAttribute[])fi.GetCustomAttributes(typeof(EnumeratorExtensionAttribute), false);
                if (attrs.Length <= 0) return null;

                stringValues.Add(value, attrs[0]);
                output = attrs[0].Value;
            }
            return output;
        }
    }
}
