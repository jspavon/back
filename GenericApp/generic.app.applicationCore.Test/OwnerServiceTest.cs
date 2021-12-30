using Moq;
using AutoMapper;
using generic.app.Infrastructure.Entities;
using generic.app.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using generic.app.api.Mapper;
using generic.app.applicationCore.Services;
using generic.app.Infrastructure.UnitOfWork;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using generic.app.common.Constants;
using System.Collections.Generic;
using generic.app.applicationCore.Dtos;

namespace generic.app.applicationCore.Test
{
    [TestClass]
    public class OwnerServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IRepositoryData<Owner>> _repository;
        private static IMapper _mapper;
        private static Mock<IUnitOfWork> _unitOfWork;

        #region Data

        public static readonly Property _property1 = new()
        {
            Id = 1,
            Name = "casa lago blue",
            Price = 1200,
            IdOwner = 1,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };


        public static readonly Owner _owner1 = new(){
            Id = 1,
            Name = "Pepito",
            Address = "Av siempre viva",
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER,            
        };

        public static readonly Owner _owner2 = new()
        {
            Id = 2,
            Name = "Ramita",
            Address = "Av siempre viva",
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };


        public static readonly List<Owner> _listOwner = new() 
        {
            _owner1,
            _owner2
        };



        public static readonly OwnerDto _ownerDto1 = new()
        {
            Name = "Pepito",
            Address = "Av siempre viva",
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };

        public static readonly OwnerUpdateDto _ownerUpdateDto1 = new()
        {
            Id = 1,
            Name = "Ramita",
            Address = "Av siempre Querer",
            CreationDate = DateTime.Now.AddDays(-1),
            CreationUser = GenericConstant.GENERIC_USER,
            ModificationDate = DateTime.Now,
            ModificationUser = GenericConstant.GENERIC_USER,
            Deleted = false
        };



        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>();
            _repository = _mockRepository.Create<IRepositoryData<Owner>>();
            _unitOfWork.Setup(sp => sp.CreateRepository<Owner>()).Returns(_repository.Object);

        }

        private OwnerService CreateService()
        {
            return new OwnerService(_repository.Object, _unitOfWork.Object, _mapper);
        }


        [TestMethod]
        public async Task GetAllAsync_Return_Ok()
        {
            _repository.Setup(x => x.GetAllAsync(
                                        It.IsAny<Expression<Func<Owner, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                                )).ReturnsAsync(_listOwner);

            var service = CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = "Id";
            bool ascending = true;
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            Equals(_listOwner, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        public void Post_Return_Ok() 
        {                        
            //Arrange
            var service = this.CreateService();    
            int Id = 0;
            OwnerDto entity = _ownerDto1;
            _repository.Setup(x => x.Insert(It.IsAny<Owner>())).Verifiable();
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = service.Post(_ownerDto1);

            //Assert
            Assert.AreEqual(Id, result.id);
            _repository.VerifyAll();
        }


        [TestMethod]
        public async Task PutAsync_ReturnsFalse_WhenIdExistsAndUpdateData()
        {
            // Arrange
            var service = CreateService();

            int Id = 1;
            OwnerUpdateDto entity = _ownerUpdateDto1;

            _repository.Setup(x => x.FirstOrDefaultAsync(
                                       It.IsAny<Expression<Func<Owner, bool>>>(),
                                       It.IsAny<Expression<Func<Owner, object>>[]>())
                           ).ReturnsAsync(_owner1);

            _repository.Setup(x => x.Update(It.IsAny<Owner>()));
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = await service.PutAsync(Id, entity);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }


        [TestMethod]
        public async Task DeleteAsync_ReturnsFalse_WhenIdExistsAndDeleteData()
        {
            // Arrange
            _repository.Setup(x => x.FirstOrDefaultAsync(
                                      It.IsAny<Expression<Func<Owner, bool>>>(),
                                      It.IsAny<Expression<Func<Owner, object>>[]>())
                          ).ReturnsAsync(_owner2);

            _repository.Setup(x => x.Delete(It.IsAny<Owner>()));
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            var service = CreateService();
            int IdOwner = 2;

            // Act
            var result = await service.DeleteAsync(IdOwner);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }

    }


}
