using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Blog.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public DateTime RegisterDate { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public User()
        {
            RegisterDate = DateTime.UtcNow;
        }
    }
}