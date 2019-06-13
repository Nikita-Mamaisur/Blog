using Blog.DataAccess.Configuration;
using Blog.DataAccess.Entities;
using System.Data.Entity;

namespace Blog.DataAccess.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
            // empty
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}