namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLatestTechAndLatestTut : DbMigration
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
                        Topic = c.Int(nullable: false),
                        Content = c.String(),
                        Url = c.String(),
                        VideoUrl = c.String(),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Topic = c.Int(nullable: false),
                        Content = c.String(),
                        Url = c.String(),
                        VideoUrl = c.String(),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LatestTutorials");
            DropTable("dbo.LatestTechnologies");
        }
    }
}
