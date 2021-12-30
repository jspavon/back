// ***********************************************************************
// Assembly         : Postobon.CCV.Core.Common
// Author           : Elkin Vasquez Isenia
// Created          : 03-05-2021
//
// Last Modified By : Elkin Vasquez Isenia
// Last Modified On : 28-04-2020
// ***********************************************************************
// <copyright file="ResponseException.cs" company="Postobon.CCV.Core.Common">
//     Copyright (c) Independiente. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace generic.app.common.Dtos
{
    /// <summary>
    /// Class ResponseException.
    /// </summary>
    /// <remarks>Jhon Steven Pavon Bedoya</remarks>
    [ExcludeFromCodeCoverage]
    public class ResponseException
    {
        /// <summary>
        /// Gets or sets the error level.
        /// </summary>
        /// <value>The error level.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string ErrorLevel { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the error source.
        /// </summary>
        /// <value>The error source.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string ErrorSource { get; set; }
        /// <summary>
        /// Gets or sets the error stack trace.
        /// </summary>
        /// <value>The error stack trace.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string ErrorStackTrace { get; set; }
        /// <summary>
        /// Gets or sets the error target site.
        /// </summary>
        /// <value>The error target site.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string ErrorTargetSite { get; set; }
        /// <summary>
        /// Gets or sets the error data.
        /// </summary>
        /// <value>The error data.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public IDictionary ErrorData { get; set; }
    }
}
