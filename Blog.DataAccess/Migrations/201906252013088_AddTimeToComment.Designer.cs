// <auto-generated />
namespace Blog.DataAccess.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddTimeToComment : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddTimeToComment));
        
        string IMigrationMetadata.Id
        {
            get { return "201906252013088_AddTimeToComment"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
