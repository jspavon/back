// ***********************************************************************
// Assembly         : Postobon.CCV.Core.Common.Proxy
// Author           : Elkin Vasquez Isenia
// Created          : 12-08-2020
//
// Last Modified By : Elkin Vasquez Isenia
// Last Modified On : 12-08-2020
// ***********************************************************************
// <copyright file="Extensions.cs" company="Postobon.CCV.Core.Common.Proxy">
//     Copyright (c) Independiente. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace generic.app.common.proxy.Configuration
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    /// <remarks>Jhon Steven Pavón Bedoya</remarks>
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="section">The section.</param>
        /// <returns>TModel.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }
    }
}
