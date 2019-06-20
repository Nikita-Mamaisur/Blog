using System;
using System.Collections.Generic;

namespace Blog.DataAccess.Entities
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}