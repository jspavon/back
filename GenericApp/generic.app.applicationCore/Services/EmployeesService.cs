using AutoMapper;
using generic.app.applicationCore.Dtos;
using generic.app.applicationCore.Interfaces;
using generic.app.common.Constants;
using generic.app.Infrastructure.Entities;
using generic.app.Infrastructure.Repository;
using generic.app.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.applicationCore.Services
{
    public class EmployeesService : IEmployeesService
    {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepositoryData<Employees> _repository;
        /// <summary>
        /// the IUnitOfWork
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <exception cref="System.ArgumentNullException">mapper</exception>
        public EmployeesService(IRepositoryData<Employees> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = unitOfWork.CreateRepository<Employees>();
            _unitOfWork = unitOfWork;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public async Task<bool> DeleteAsync(int id)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (existingEntity is null) return false;

            existingEntity.ModificationUser = GenericConstant.GENERIC_USER;
            existingEntity.ModificationDate = DateTime.Now;
            existingEntity.Deleted = true;

            _repository.Update(existingEntity);
            return _unitOfWork.Save() > 0;
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>Task&lt;IEnumerable&lt;EmployeesDto&gt;&gt;.</returns>
        public async Task<IEnumerable<EmployeesDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = _repository.GetAllAsync(x => !x.Deleted, page, limit, orderBy, ascending).Result.OrderBy(x => x.Nombres);
            var mapper = _mapper.Map<IEnumerable<EmployeesDto>>(result);
            return mapper;
        }

        /// <summary>
        /// get by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;EmployeesDto&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public async Task<EmployeesDto> GetByIdAsync(int id)
        {
            var result = _repository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted).Result;
            var mapper = _mapper.Map<EmployeesDto>(result);
            return mapper;
        }

        /// <summary>
        /// Posts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.ValueTuple&lt;System.Boolean, System.Int32&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public (bool status, int id) Post(EmployeesDto entity)
        {
            var obj = _mapper.Map<Employees>(entity);
            obj.CreationUser = GenericConstant.GENERIC_USER;
            obj.CreationDate = DateTime.Now;

            _repository.Insert(obj);
            var result = _unitOfWork.Save() > 0;
            return (result, obj.Id);
        }

        /// <summary>
        /// put as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        public async Task<bool> PutAsync(int id, EmployeesDto entity)
        {
            var existingEntity = _repository.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (existingEntity == null) return false;
            _mapper.Map(entity, existingEntity);

            existingEntity.ModificationUser = GenericConstant.GENERIC_USER;
            existingEntity.ModificationDate = DateTime.Now;
            _repository.Update(existingEntity);
            return _unitOfWork.Save() > 0;
        }

    }
}
