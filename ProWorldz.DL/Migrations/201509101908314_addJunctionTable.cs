namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJunctionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasterFilePaths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MasterUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.LatestTutorials", "Content");
            DropColumn("dbo.LatestTutorials", "Url");
            DropColumn("dbo.LatestTutorials", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LatestTutorials", "FilePath", c => c.String());
            AddColumn("dbo.LatestTutorials", "Url", c => c.String());
            AddColumn("dbo.LatestTutorials", "Content", c => c.String());
            DropTable("dbo.MasterUrls");
            DropTable("dbo.MasterFilePaths");
            DropTable("dbo.MasterContents");
        }
    }
}
