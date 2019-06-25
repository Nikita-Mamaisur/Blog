using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using System;
using System.Data.Entity;
using System.Linq;
using Blog.DataServices.Mapping;
using System.Collections.Generic;

namespace Blog.DataServices.Services
{
    public class PostsService
    {
        private readonly DbContext _context;
        private readonly DbSet<User> _userSet;
        private readonly DbSet<Post> _postSet;
        private readonly DbSet<Comment> _commentSet;

        public PostsService(DbContext context)
        {
            _context = context;
            _userSet = _context.Set<User>();
            _postSet = context.Set<Post>();
            _commentSet = context.Set<Comment>();
        }

        public void Add(PostModel model, string userId)
        {
            var user = new User() { Id = userId };
            _userSet.Attach(user);

            var post = new Post()
            {
                Title = model.Title,
                Body = model.Body,
                Slug = model.Slug,
                Date = DateTime.UtcNow,
                Author = user
            };

            _postSet.Add(post);
            _context.SaveChanges();

            model.Id = post.Id;
        }

        public void AddComment(CommentModel model, string userId)
        {
            var user = new User() { Id = userId };
            var post = new Post() { Id = model.PostId };

            _userSet.Attach(user);
            _postSet.Attach(post);

            var comment = new Comment()
            {
                Author = user,
                Post = post,
                Text = model.Text,
			   _date = DateTime.UtcNow    //date
			};

            _commentSet.Add(comment);
            _context.SaveChanges();

            model.Id = comment.Id;
        }

        public PostModel FindBySlug(string slug)
        {
            return _postSet.Where(x => x.Slug == slug)
                .SelectPostModel()
                .SingleOrDefault();
        }

        public PostModel FindById(Guid guid)
        {
            return _postSet.Where(x => x.Id == guid)
                .SelectPostModel()
                .SingleOrDefault();
        }

        public List<PostModel> GetLastPosts(int count)
        {
            return _postSet.OrderByDescending(p => p.Date)
                .Take(count)
                .SelectPostModel()
                .ToList();
        }

    }
}