// ***********************************************************************
// Assembly         : Postobon.CCV.Core.Infrastructure
// Author           : Elkin Vasquez Isenia
// Created          : 03-05-2021
//
// Last Modified By : Elkin Vasquez Isenia
// Last Modified On : 12-08-2020
// ***********************************************************************
// <copyright file="Repository.cs" company="Postobon.CCV.Core.Infrastructure">
//     Copyright (c) Independiente. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using generic.app.Infrastructure.Context;
using generic.app.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace generic.app.Infrastructure.Repository
{
    /// <summary>
    /// Class Repository.
    /// Implements the <see cref="IRepository{TEntity}" />
    /// Implements the <see cref="Postobon.CCV.Core.Infrastructure.DataAccess.Repository.IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="Postobon.CCV.Core.Infrastructure.DataAccess.Repository.IRepository{TEntity}" />
    /// <seealso cref="IRepository{TEntity}" />
   
    [ExcludeFromCodeCoverage]
    public class RepositoryData<TEntity> : IRepositoryData<TEntity> where TEntity : class
    {
        /// <summary>
        /// The dbcontext
        /// </summary>
        private readonly IDataContext _dataContext;

        /// <summary>
        /// The entities
        /// </summary>
        private readonly DbSet<TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
        /// </summary>
        /// <param name="dbcontext">The dbcontext.</param>
        /// <param name="unitOfWork">The unit of work.</param>       
        public RepositoryData(IDataContext dbcontext)
        {
            _dataContext = dbcontext;
            _entities = dbcontext.Set<TEntity>();
        }

        // Include lambda expressions in queries
        /// <summary>
        /// Performs the inclusions.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>       
        private IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties, IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<TEntity> Members

#pragma warning disable 1998

        /// <summary>
        /// Ases the queryable.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        /// Retorna un objeto del tipo AsQueryable
       
        public async Task<IQueryable<TEntity>> AsQueryable()
        {
            return _entities.AsQueryable();
        }

#pragma warning disable 1998

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        /// Función que retorna una entidad, a partir de una consulta.       
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>       
        public async Task<IEnumerable<TEntity>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable(), page, limit, orderBy, ascending);

            return result;
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>       
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where, int page, int limit, string orderBy, bool ascending = true)
        {
            return await PagedResult<TEntity>.ToPagedListAsync(_entities.AsQueryable().Where(where), page, limit, orderBy, ascending);
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la primera entidad encontrada bajo una condición especificada o null sino encontrara registros       
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        /// <summary>
        /// Lasts the or default.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>TEntity.</returns>
        /// Retorna la ultima entidad encontrada bajo una condición especificada o null sino encontrara registros       
        public async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.LastOrDefault(where);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Registra una entidad       
        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Registra varias entidades       
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Added;
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Actualiza una entidad       
        public virtual void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Actualiza varias entidades       
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Elimina una entidad       
        public virtual void Delete(TEntity entity)
        {
            if (_dataContext.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Elimina por Id       
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _entities.Find(id);
            _entities.Remove(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Elimina un conjuto de entidades       
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                _dataContext.Entry(e).State = EntityState.Deleted;
            }
        }

        #endregion IRepository<TEntity> Members
    }
}
