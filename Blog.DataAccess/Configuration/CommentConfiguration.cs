using Blog.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Blog.DataAccess.Configuration
{
    internal class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Text)
                .HasMaxLength(500)
                .IsVariableLength()
                .IsUnicode()
                .IsRequired();

            HasRequired(c => c.Post)
                .WithMany(p => p.Comments)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Author)
                .WithMany(p => p.Comments)
                .WillCascadeOnDelete(false);
        }
    }
}
