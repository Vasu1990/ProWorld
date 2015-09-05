namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LatestTechnologies", "Topic", c => c.String());
            AlterColumn("dbo.LatestTutorials", "Topic", c => c.String());
            CreateIndex("dbo.LatestTechnologies", "UserId");
            CreateIndex("dbo.LatestTutorials", "UserId");
            AddForeignKey("dbo.LatestTechnologies", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.LatestTutorials", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LatestTutorials", "UserId", "dbo.Users");
            DropForeignKey("dbo.LatestTechnologies", "UserId", "dbo.Users");
            DropIndex("dbo.LatestTutorials", new[] { "UserId" });
            DropIndex("dbo.LatestTechnologies", new[] { "UserId" });
            AlterColumn("dbo.LatestTutorials", "Topic", c => c.Int(nullable: false));
            AlterColumn("dbo.LatestTechnologies", "Topic", c => c.Int(nullable: false));
        }
    }
}
