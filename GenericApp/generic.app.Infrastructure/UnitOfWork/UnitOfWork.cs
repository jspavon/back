// ***********************************************************************
// Assembly         : Postobon.CCV.Core.Infrastructure
// Author           : Elkin Vasquez Isenia
// Created          : 03-05-2021
//
// Last Modified By : Elkin Vasquez Isenia
// Last Modified On : 26-04-2020
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="Postobon.CCV.Core.Infrastructure">
//     Copyright (c) Independiente. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using generic.app.Infrastructure.Context;
using generic.app.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace generic.app.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Class UnitOfWork.
    /// Implements the <see cref="IUnitOfWork" />
    /// Implements the <see cref="IUnitOfWork" />
    /// Implements the <see cref="Postobon.CCV.Core.Infrastructure.DataAccess.UnitOfWork.IUnitOfWork" />
    /// </summary>
    /// <seealso cref="Postobon.CCV.Core.Infrastructure.DataAccess.UnitOfWork.IUnitOfWork" />
    /// <seealso cref="IUnitOfWork" />
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {       

        #region Attributes

        /// <summary>
        /// The context
        /// </summary>
        private readonly IDataContext _dataContext;

        /// <summary>
        /// The repository factory.
        /// </summary>
        private readonly IRepositoryFactory _repositoryFactory;

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public UnitOfWork(IDataContext dataContext, IRepositoryFactory repositoryFactory)
        {
            _dataContext = dataContext;
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public UnitOfWork()
        {
        }

        #endregion


        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public void Dispose() => _dataContext.Dispose();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public int Save() => _dataContext.Save();

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> SaveAsync()
        {
           return await _dataContext.SaveAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() => _dataContext.Clear();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public void Rollback() => _dataContext.RollBack();

        /// <summary>
        /// Create Repository
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepositoryData<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            return _repositoryFactory.CreateRepository<TEntity>();
        }
        #endregion
    }
}
