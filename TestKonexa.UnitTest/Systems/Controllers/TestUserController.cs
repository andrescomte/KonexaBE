using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestKonexa.API.Controllers;
using TestKonexa.API.Model;
using TestKonexa.API.Service;
using TestKonexa.UnitTest.Fixtures;

namespace TestKonexa.UnitTest.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async void Get_ReturnStatusCode200()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixtures.GetTestUsers());
            var sut = new UserController(mockUserService.Object);
            var result = (OkObjectResult)await sut.Get();
            List<User>? usuarios = result.Value as List<User>;
            Assert.True(usuarios.Count() == 3, "debe retornar 3 usuarios");
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void Get_InvokesUserService()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixtures.GetTestUsers());
            var sut = new UserController(mockUserService.Object);
            var result = await sut.Get();
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Get_ReturnListUsers()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixtures.GetTestUsers());
            var sut = new UserController(mockUserService.Object);
            var result = await sut.Get();
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
            result.Should().NotBeNull();
        }

        [Fact]
        public async void Get_ReturnNotFound()
        {
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());
            var sut = new UserController(mockUserService.Object);
            var result = await sut.Get();
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}