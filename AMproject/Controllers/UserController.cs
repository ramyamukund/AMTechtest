using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AMproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMproject.Services;
using Newtonsoft.Json;

namespace AMproject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserPostService _userPostService;

        public UserController(ILogger<UserController> logger, IUserPostService userPostService)
        {
            _logger = logger;
            _userPostService = userPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userPostService.GetUsers();

            var posts = await _userPostService.GetPosts();

            var postByUsers = posts
           .GroupBy(n => n.userId)
           .Select(p => new UserPostModel
           {
               userId = p.Key,
               numberOfPosts = p.Count()
           }
           )
           .OrderBy(n => n.userId);

            var userPostInfo = users.Join(postByUsers, user => user.id, pbu => pbu.userId,
                (user, pbu) => new UserPostModel
                {
                    userId = user.id,
                    name = user.name,
                    userName = user.username,
                    numberOfPosts = pbu.numberOfPosts

                }).ToList();


            return View(userPostInfo);
        }

        [HttpGet]
        [Route("User/Details/{userId:int}")]
        public async Task<IActionResult> Details(int userId)
        {
            var users = await _userPostService.GetUsers();

            var posts = await _userPostService.GetPosts();

            var userPosts = posts.Where(up => up.userId == userId).ToList();

            var  user = users.Where(u => u.id == userId).FirstOrDefault();

            var userPostInfo = users.Join(userPosts, user => user.id, up => up.userId,
                (user, up) => new UserPostModel
                {
                    user = user,
                    posts = userPosts


                }).FirstOrDefault();

            return View(userPostInfo);
        }
    }
}
