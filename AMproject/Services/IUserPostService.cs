using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AMproject.Models;

namespace AMproject.Services
{
    public interface IUserPostService
    {
        Task<List<UserModel>> GetUsers();

        Task<List<PostModel>> GetPosts();
    }
}
