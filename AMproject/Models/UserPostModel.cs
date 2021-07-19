using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMproject.Models
{
    public class UserPostModel
    {
        public int userId { get; set; }

        public string userName { get; set; }

        public string name { get; set; }

        public UserModel user { get; set; }
        public int numberOfPosts { get; set; }

        public List<PostModel> posts { get; set; }
    }
}
