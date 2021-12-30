// ***********************************************************************
// Assembly         : Postobon.CCV.Core.Infrastructure
// Author           : Elkin Vasquez Isenia
// Created          : 03-05-2021
//
// Last Modified By : Elkin Vasquez Isenia
// Last Modified On : 28-04-2020
// ***********************************************************************
// <copyright file="ExtensionsOrderBy.cs" company="Postobon.CCV.Core.Infrastructure">
//     Copyright (c) Independiente. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using generic.app.common.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace generic.app.Infrastructure.Pagination
{
    /// <summary>
    /// Class ExtensionsOrderBy.
    /// </summary>
    /// <remarks>Elkin Vasquez Isenia</remarks>
    [ExcludeFromCodeCoverage]
    public static class ExtensionsOrderBy
    {
        /// <summary>
        /// Order the IQueryable by the given property or field.
        /// </summary>
        /// <typeparam name="T">The type of the IQueryable being ordered.</typeparam>
        /// <param name="queryable">The IQueryable being ordered.</param>
        /// <param name="propertyOrFieldName">The name of the property or field to order by.</param>
        /// <param name="ascending">Indicates whether or not the order should be ascending (true) or descending (false.)</param>
        /// <returns>Returns an IQueryable ordered by the specified field.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable, string propertyOrFieldName, bool ascending = true)
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending
                ? GenericEnumerator.OrderByMethod.OrderBy.ToString()
                : GenericEnumerator.OrderByMethod.OrderByDescending.ToString();

            var parameterExpression = Expression.Parameter(elementType);
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpression, parameterExpression);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName, new[] { elementType, propertyOrFieldExpression.Type }, queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
