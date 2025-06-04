using Xunit;
using AutoMapper;
using Moq;
using System.Threading.Tasks;
using Games.Api.Controllers;
using Games.Core.service;
using Games.Core;
using Games.Api;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class UserTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _controller;
        private readonly IMapper _mapper;

        public UserTest()
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            _mapper = config.CreateMapper();

            // Mock service
            _userServiceMock = new Mock<IUserService>();

            // Initialize controller with mock service and mapper
            _controller = new UsersController(_userServiceMock.Object, _mapper);
        }
        //בדיקה האם משתמש קיים
        [Fact]
        public async Task GetById_ValidId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var userDTO = new UserDTO
            {
                Id = userId,
                FirstName = "Test",
                LastName = "Test",
                Address = "Test",
                Email = "Test",
                UserName = "Test",
                Password = "Test",
                Phone = "Test",
            };
            var user = new User
            {
                Id = userId,
                FirstName = "Test",
                LastName = "Test",
                Address = "Test",
                Email = "Test",
                UserName = "Test",
                Password = "Test",
                Phone = "Test",
            };
            _userServiceMock
       .Setup(s => s.getById(userId))
       .Returns(user);  // שימוש ב-ReturnsAsync כדי להחזיר Task<User>

            // Act
            var result = _controller.Get(userId);
            Console.WriteLine(result);
            Assert.IsType<UserDTO>(result);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDTO.Id, result.Id);
            Assert.Equal(userDTO.FirstName, result.FirstName);
            Assert.Equal(userDTO.LastName, result.LastName);
            Assert.Equal(userDTO.Address, result.Address);
            Assert.Equal(userDTO.Email, result.Email);
            Assert.Equal(userDTO.UserName, result.UserName);
            Assert.Equal(userDTO.Password, result.Password);
            Assert.Equal(userDTO.Phone, result.Phone);

        }



        //בדיקה על פונקציית החזרת משתמש לפי שם משתמש וסיסמה
        [Fact]
        public async Task Get_ValidLogin_ReturnsOkWithUser()
        {
            // Arrange
            var loginRequest = new LoginRequest { Name = "testUser", Password = "testPassword" };
            var user = new User { Id = 1, UserName = "testUser", Password = "testPassword" };
            var userDTO = new UserDTO { Id = 1, UserName = "testUser" };

            _userServiceMock
                .Setup(s => s.getByUserNameAndPassword(loginRequest.Name, loginRequest.Password))
                .Returns(user); // מחזיר משתמש תקף

            // Act
            var result = _controller.Get(loginRequest);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedUser = Assert.IsType<UserDTO>(okResult.Value);

            Assert.Equal(userDTO.Id, returnedUser.Id);
            Assert.Equal(userDTO.UserName, returnedUser.UserName);
        }
    }
}
