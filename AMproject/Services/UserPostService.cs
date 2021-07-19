using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using AMproject.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;


namespace AMproject.Services
{
    public class UserPostService : IUserPostService
    {
        private HttpClient _httpClient;

        private IConfiguration _configuration;
        public UserPostService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
                    
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var response = await _httpClient.GetAsync($"{_configuration.GetValue<string>("UserPostServiceEndPoint:BaseUrl")}/users");
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ReadAsStringAsync().Result);

            return users;


        }

        public async Task<List<PostModel>> GetPosts()
        {
            var response = await _httpClient.GetAsync($"{_configuration.GetValue<string>("UserPostServiceEndPoint:BaseUrl")}/posts");
            var posts = JsonConvert.DeserializeObject<List<PostModel>>(response.Content.ReadAsStringAsync().Result);

            return posts;
        }
    }
}
