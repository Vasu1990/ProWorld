namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merging_162015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LatestTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommunityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SubCommunityId = c.Int(nullable: false),
                        Subject = c.String(),
                        Tag = c.String(),
                        Topic = c.String(),
                        Content = c.String(),
                        Url = c.String(),
                        VideoUrl = c.String(),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LatestTutorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommunityId = c.Int(nullable: false),
                        SubCommunityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Subject = c.String(),
                        Tag = c.String(),
                        Topic = c.String(),
                        Content = c.String(),
                        Url = c.String(),
                        VideoUrl = c.String(),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LatestTutorials", "UserId", "dbo.Users");
            DropForeignKey("dbo.LatestTechnologies", "UserId", "dbo.Users");
            DropIndex("dbo.LatestTutorials", new[] { "UserId" });
            DropIndex("dbo.LatestTechnologies", new[] { "UserId" });
            DropTable("dbo.LatestTutorials");
            DropTable("dbo.LatestTechnologies");
        }
    }
}
