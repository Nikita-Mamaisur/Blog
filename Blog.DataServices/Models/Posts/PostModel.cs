using System;

namespace Blog.DataServices.Models.Posts
{
    public class PostModel
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}