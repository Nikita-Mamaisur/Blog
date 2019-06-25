using Blog.DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Blog.DataAccess.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(x => x.RegisterDate)
                .HasColumnType("date")
                .IsRequired();

            HasMany(x => x.Posts)
                .WithRequired(x => x.Author)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Author)
                .WillCascadeOnDelete(false);
        }
    }
}
