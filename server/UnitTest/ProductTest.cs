using Xunit;
using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Games.Api.Controllers;
using Games.Core.service;
using Games.Core;

namespace UnitTest
{
    public class ProductTest
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductsController _controller;
        private readonly IMapper _mapper;

        public ProductTest()
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            _mapper = config.CreateMapper();

            // Mock service
            _productServiceMock = new Mock<IProductService>();

            // Initialize controller with mock service and mapper
            _controller = new ProductsController(_productServiceMock.Object, _mapper);
        }
        //בדיקה האם מוצר קיים (קוד תקין
        [Fact]
        public async Task GetById_ValidId_ReturnsProduct()
        {
            // Arrange
            var productId = 1;
            var productDTO = new ProductDTO
            {
                Id = productId,
                Name = "name",
                CategoryId = 1,
                Description = "description",
                Price = 20,
                Quantity = 10,
                ImageSrc = "imageSrc"
            };
            var product = new Product
            {
                Id = productId,
                Name = "name",
                CategoryId = 1,
                Description = "description",
                Price = 20,
                quantity = 10,
                ImageSrc = "imageSrc"
            };
            _productServiceMock
                .Setup(s => s.getById(productId))
                .Returns(product);

            // Act
            var result = _controller.Get(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productDTO.Id, result.Id);
            Assert.Equal(productDTO.Name, result.Name);
            Assert.Equal(productDTO.CategoryId, result.CategoryId);
            Assert.Equal(productDTO.Description, result.Description);
            Assert.Equal(productDTO.Price, result.Price);
            Assert.Equal(productDTO.Quantity, result.Quantity);
            Assert.Equal(productDTO.ImageSrc, result.ImageSrc);
        }

        //בדיקה האם מוצר קיים (קוד לא תקין
        [Fact]
        public async Task GetById_NotValidId_ReturnsNull()
        {
            // Arrange
            var productId = -1;
            var product = new Product
            {
                Id = 1,
                Name = "name",
                CategoryId = 1,
                Description = "description",
                Price = 20,
                quantity = 10,
                ImageSrc = "imageSrc"
            };
            _productServiceMock
                .Setup(s => s.getById(1))
                .Returns(product);

            // Act
            var result = _controller.Get(productId);

            // Assert
            Assert.Null(result);

        }

      //בדיקה על פונקציית החזרת מוצרים שהכמות במלאי =0 , שחוזרת רשימה ריקה כאשר אין מוצרים כאלה
        [Fact]
        public async Task GetFinished_ReturnsEmpty()
        {
            // Arrange
            List<Product> products = new List<Product>();
            _productServiceMock
                .Setup(s => s.getfinished())
                .Returns(products);

            // Act
            var result = _controller.GetFinished();

            // Assert
            Assert.Empty(result);
        }
    }
}
