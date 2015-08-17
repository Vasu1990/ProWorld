namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecomm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGeneralInfomations", "CommunityId", "dbo.Communities");
            DropIndex("dbo.UserGeneralInfomations", new[] { "CommunityId" });
            DropColumn("dbo.UserGeneralInfomations", "CommunityId");
            DropColumn("dbo.UserGeneralInfomations", "SubCommunityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGeneralInfomations", "SubCommunityId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGeneralInfomations", "CommunityId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGeneralInfomations", "CommunityId");
            AddForeignKey("dbo.UserGeneralInfomations", "CommunityId", "dbo.Communities", "Id");
        }
    }
}
