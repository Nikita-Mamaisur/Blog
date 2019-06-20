using Blog.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Blog.DataAccess.Configuration
{
    internal class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Slug)
                .HasMaxLength(50)
                .IsVariableLength()
                .IsUnicode(false)
                .IsRequired();

            Property(p => p.Title)
                .HasMaxLength(100)
                .IsVariableLength()
                .IsUnicode()
                .IsRequired();

            Property(p => p.Body)
                .IsVariableLength()
                .IsUnicode()
                .IsRequired();

            Property(p => p.Date)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();

            HasIndex(p => p.Slug)
                .IsUnique(true)
                .IsClustered(false);

            HasMany(p => p.Comments)
                .WithRequired(c => c.Post);
        }
    }
}
