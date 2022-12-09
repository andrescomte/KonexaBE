using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestKonexa.API.Model;
using TestKonexa.API.Service;
using TestKonexa.UnitTest.Fixtures;
using TestKonexa.UnitTest.Helpers;

namespace TestKonexa.UnitTest.Systems.Service
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUser_InvokesHttpGetRequest()
        {
            var expectedResponse = UsersFixtures.GetTestUsers();
            var handleMock = MockHttpClient<User>.GetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new UsersService(httpClient);
            var users = await sut.GetAllUsers();
            handleMock
                .Protected()
                .Verify("SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), 
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetAllUser_ReturnListUsers()
        {
            var expectedResponse = UsersFixtures.GetTestUsers();
            var handleMock = MockHttpClient<User>.GetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new UsersService(httpClient);
            var result = await sut.GetAllUsers();
            result.Should().BeOfType<List<User>>();
            result.Count.Should().Be(3);
            Assert.True(result.Count == 3, "Debe retornar 3 usuarios");
        }
    }
}
