using NUnit.Framework;
using AMproject.Services;
using System.Net.Http;
using AMproject.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using FakeItEasy;

namespace AMProject.UnitTests
{
    public class UserPostServiceTests
    {
       
        [Test]
        public async Task GetUsers_Test()
        {
            //Arrange

            var userPostService = A.Fake<IUserPostService>();
            var users = A.CollectionOfDummy<UserModel>(5).AsEnumerable();
            A.CallTo(() => userPostService.GetUsers()).Returns(Task.FromResult(users.ToList()));

            //Act

            var actualResult = await userPostService.GetUsers();

            //Assert

            var expectedResult = 5;

            Assert.AreEqual(expectedResult, actualResult.Count());

        }

        [Test]
        public async Task GetPosts_Test()
        {

            //Arrange

            var userPostService = A.Fake<IUserPostService>();
            var posts = A.CollectionOfDummy<PostModel>(100).AsEnumerable();
            A.CallTo(() => userPostService.GetPosts()).Returns(Task.FromResult(posts.ToList()));

            //Act

            var actualResult = await userPostService.GetPosts();

            //Assert

            var expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult.Count());

        }
    }
}