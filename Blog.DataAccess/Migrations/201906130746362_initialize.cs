namespace Blog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        Post_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Slug = c.String(nullable: false, maxLength: 50, unicode: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Slug, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "Slug" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
