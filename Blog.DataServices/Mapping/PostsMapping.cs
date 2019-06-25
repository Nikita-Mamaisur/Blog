using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using System.Linq;

namespace Blog.DataServices.Mapping
{
    public static partial class Mapping
    {
        public static IQueryable<PostModel> SelectPostModel(this IQueryable<Post> query)
        {
            // TODO: Повторение кода
            return query.Select(x => new PostModel()
            {
                Id = x.Id,
                Body = x.Body,
                Slug = x.Slug,
                Title = x.Title,
                Date = x.Date,
                Comments = x.Comments
                    .Select(c => new CommentModel()
                    {
                        Id = c.Id,
                        PostId = c.Post.Id,
                        Text = c.Text
                    })
                    .ToList()
            });
        }

        public static IQueryable<CommentModel> SelectCommentModel(this IQueryable<Comment> query)
        {
            return query.Select(x => new CommentModel()
            {
                Id = x.Id,
                PostId = x.Post.Id,
                Text = x.Text
            });
        }
    }
}