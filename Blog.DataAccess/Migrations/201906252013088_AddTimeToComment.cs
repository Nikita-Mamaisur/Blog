namespace Blog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "_date", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "_date");
        }
    }
}
