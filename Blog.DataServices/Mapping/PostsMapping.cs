using Blog.DataAccess.Entities;
using Blog.DataServices.Models.Posts;
using System.Linq;

namespace Blog.DataServices.Mapping
{
    public static partial class Mapping
    {
        public static IQueryable<PostModel> SelectPostModel(this IQueryable<Post> query)
        {
            return query.Select(x => new PostModel()
            {
                Id = x.Id,
                Body = x.Body,
                Slug = x.Slug,
                Title = x.Title,
                Date = x.Date
            });
        }
    }
}