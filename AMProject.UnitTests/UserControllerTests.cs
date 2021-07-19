using NUnit.Framework;
using AMproject.Services;
using System.Net.Http;
using AMproject.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using FakeItEasy;
using AMproject.Controllers;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;

namespace AMProject.UnitTests
{
    public class UserControllerTests
    {
        [Test]
        public async Task UserController_Get_Test()
        {
            //Arrange

            var logger = A.Fake<ILogger<UserController>>();

            var userPostService = A.Fake<IUserPostService>();
            var users = A.CollectionOfDummy<UserModel>(10).AsEnumerable();
            A.CallTo(() => userPostService.GetUsers()).Returns(Task.FromResult(users.ToList()));

            var posts = A.CollectionOfDummy<PostModel>(10).AsEnumerable();
            A.CallTo(() => userPostService.GetPosts()).Returns(Task.FromResult(posts.ToList()));

            var controller = new UserController(logger, userPostService);

            //Act

            var result = await controller.Index();
            var resultDet = await controller.Details(1);

            //Assert

            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(resultDet, Is.InstanceOf<ViewResult>());
        }
    }
}
