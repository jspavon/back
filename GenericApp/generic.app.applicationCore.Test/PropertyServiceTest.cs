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
    public class PropertyServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IRepositoryData<Property>> _repository;
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


        public static readonly Property _property2 = new()
        {
            Id = 2,
            Name = "casa lago red",
            Price = 1200,
            IdOwner = 2,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };


        public static readonly List<Property> _listProperty = new() 
        {
            _property1,
            _property2
        };


        public static readonly PropertyDto _propertyDto1 = new()
        {
            Name = "casa lago blue",
            Price = 1200,
            IdOwner = 1,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };

        public static readonly PropertyUpdateDto _propertyUpdateDto1 = new()
        {
            Name = "casa lago blue",
            Price = 1200,
            IdOwner = 1,
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
            _repository = _mockRepository.Create<IRepositoryData<Property>>();
            _unitOfWork.Setup(sp => sp.CreateRepository<Property>()).Returns(_repository.Object);

        }

        private PropertyService CreateService()
        {
            return new PropertyService(_repository.Object, _unitOfWork.Object, _mapper);
        }


        [TestMethod]
        public async Task GetAllAsync_Return_Ok()
        {
            _repository.Setup(x => x.GetAllAsync(
                                        It.IsAny<Expression<Func<Property, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                                )).ReturnsAsync(_listProperty);

            var service = CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = "Id";
            bool ascending = true;
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            Equals(_listProperty, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        public void Post_Return_Ok() 
        {                        
            //Arrange
            var service = this.CreateService();    
            int Id = 0;
            PropertyDto entity = _propertyDto1;
            _repository.Setup(x => x.Insert(It.IsAny<Property>())).Verifiable();
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = service.Post(_propertyDto1);

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
            PropertyUpdateDto entity = _propertyUpdateDto1;

            _repository.Setup(x => x.FirstOrDefaultAsync(
                                       It.IsAny<Expression<Func<Property, bool>>>(),
                                       It.IsAny<Expression<Func<Property, object>>[]>())
                           ).ReturnsAsync(_property1);

            _repository.Setup(x => x.Update(It.IsAny<Property>()));
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
                                      It.IsAny<Expression<Func<Property, bool>>>(),
                                      It.IsAny<Expression<Func<Property, object>>[]>())
                          ).ReturnsAsync(_property2);

            _repository.Setup(x => x.Delete(It.IsAny<Property>()));
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            var service = CreateService();
            int IdProperty = 2;

            // Act
            var result = await service.DeleteAsync(IdProperty);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }

    }


}
