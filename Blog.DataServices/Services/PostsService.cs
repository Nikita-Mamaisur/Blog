using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using System;
using System.Data.Entity;
using System.Linq;

namespace Blog.DataServices.Services
{
    public class PostsService
    {
        private readonly DbContext _context;
        private readonly DbSet<Post> _set;

        public PostsService(DbContext context)
        {
            _context = context;
            _set = context.Set<Post>();
        }

        public void Add(PostModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Body = model.Body,
                Slug = model.Slug
            };

            _set.Add(post);
            _context.SaveChanges();

            model.Id = post.Id;
        }

        public object FindBySlug(string slug)
        {
            var post = _set.SingleOrDefault(p => p.Slug == slug);

            if (post != null)
            {
                return new PostModel()
                {
                    Id = post.Id,
                    Body = post.Body,
                    Slug = post.Slug,
                    Title = post.Title
                };
            }

            return null;
        }

        public PostModel FindById(Guid guid)
        {
            var post = _set.SingleOrDefault(p => p.Id == guid);

            if (post != null)
            {
                return new PostModel()
                {
                    Id = post.Id,
                    Body = post.Body,
                    Slug = post.Slug,
                    Title = post.Title
                };
            }

            return null;
        }
    }
}