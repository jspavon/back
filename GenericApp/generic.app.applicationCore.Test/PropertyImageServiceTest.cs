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
    public class PropertyImageServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IRepositoryData<PropertyImage>> _repository;
        private static IMapper _mapper;
        private static Mock<IUnitOfWork> _unitOfWork;

        #region Data

        public static readonly PropertyImage _propertyImage1 = new()
        {
            Id = 1,
            IdProperty = 1,
            File = "https://cdn.bhdw.net/im/minato-namikaze-naruto-shippuden-papel-pintado-55053_L.jpg",
            Enabled = true,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER,            
        };

        public static readonly PropertyImage _propertyImage2 = new()
        {
            Id = 2,
            IdProperty = 2,
            File = "https://www.cinepremiere.com.mx/wp-content/uploads/2021/05/Goku-articulo-900x491.jpg",
            Enabled = true,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };


        public static readonly List<PropertyImage> _listPropertyImage = new() 
        {
            _propertyImage1,
            _propertyImage2
        };



        public static readonly PropertyImageDto _propertyImageDto1 = new()
        {
            IdProperty = 1,
            File = "https://cdn.bhdw.net/im/minato-namikaze-naruto-shippuden-papel-pintado-55053_L.jpg",
            Enabled = true,
            CreationDate = DateTime.Now,
            CreationUser = GenericConstant.GENERIC_USER
        };

        public static readonly PropertyImageUpdateDto _propertyImageUpdateDto1 = new()
        {
            Id = 2,
            IdProperty = 2,
            File = "https://www.cinepremiere.com.mx/wp-content/uploads/2021/05/Goku-articulo-900x491.jpg",
            Enabled = true,
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
            _repository = _mockRepository.Create<IRepositoryData<PropertyImage>>();
            _unitOfWork.Setup(sp => sp.CreateRepository<PropertyImage>()).Returns(_repository.Object);

        }

        private PropertyImageService CreateService()
        {
            return new PropertyImageService(_repository.Object, _unitOfWork.Object, _mapper);
        }


        [TestMethod]
        public async Task GetAllAsync_Return_Ok()
        {
            _repository.Setup(x => x.GetAllAsync(
                                        It.IsAny<Expression<Func<PropertyImage, bool>>>(),
                                        It.IsAny<int>(),
                                        It.IsAny<int>(),
                                        It.IsAny<string>(),
                                        It.IsAny<bool>()
                                )).ReturnsAsync(_listPropertyImage);

            var service = CreateService();
            int page = 1;
            int limit = 100;
            string orderBy = "Id";
            bool ascending = true;
            var result = await service.GetAllAsync(page, limit, orderBy, ascending);

            Equals(_listPropertyImage, result);
            _repository.VerifyAll();
        }

        [TestMethod]
        public void Post_Return_Ok() 
        {                        
            //Arrange
            var service = this.CreateService();    
            int Id = 0;
            PropertyImageDto entity = _propertyImageDto1;
            _repository.Setup(x => x.Insert(It.IsAny<PropertyImage>())).Verifiable();
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            // Act
            var result = service.Post(_propertyImageDto1);

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
            PropertyImageUpdateDto entity = _propertyImageUpdateDto1;

            _repository.Setup(x => x.FirstOrDefaultAsync(
                                       It.IsAny<Expression<Func<PropertyImage, bool>>>(),
                                       It.IsAny<Expression<Func<PropertyImage, object>>[]>())
                           ).ReturnsAsync(_propertyImage1);

            _repository.Setup(x => x.Update(It.IsAny<PropertyImage>()));
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
                                      It.IsAny<Expression<Func<PropertyImage, bool>>>(),
                                      It.IsAny<Expression<Func<PropertyImage, object>>[]>())
                          ).ReturnsAsync(_propertyImage2);

            _repository.Setup(x => x.Delete(It.IsAny<PropertyImage>()));
            _unitOfWork.Setup(s => s.SaveAsync()).ReturnsAsync(1);

            var service = CreateService();
            int IdPropertyImage = 2;

            // Act
            var result = await service.DeleteAsync(IdPropertyImage);

            // Assert
            Assert.IsFalse(result);
            _repository.VerifyAll();
        }

    }


}
