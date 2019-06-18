using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using System;
using System.Data.Entity;
using System.Linq;
using Blog.DataServices.Mapping;

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

        public PostModel FindBySlug(string slug)
        {
            return _set.Where(x => x.Slug == slug)
                .SelectPostModel()
                .SingleOrDefault();
        }

        public PostModel FindById(Guid guid)
        {
            return _set.Where(x => x.Id == guid)
                .SelectPostModel()
                .SingleOrDefault();
        }
    }
}