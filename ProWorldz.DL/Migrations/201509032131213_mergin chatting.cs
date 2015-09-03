namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merginchatting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGeneralInfomations", "CommunityId", "dbo.Communities");
            DropIndex("dbo.UserGeneralInfomations", new[] { "CommunityId" });
            AddColumn("dbo.UserGeneralInfomations", "Address1", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "Address2", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "Status", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "FatherName", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "PhoneNumber", c => c.String());
            DropColumn("dbo.UserGeneralInfomations", "CommunityId");
            DropColumn("dbo.UserGeneralInfomations", "SubCommunityId");
            DropColumn("dbo.UserPersonalInfomations", "Address1");
            DropColumn("dbo.UserPersonalInfomations", "Address2");
            DropColumn("dbo.UserPersonalInfomations", "Status");
            DropColumn("dbo.UserPersonalInfomations", "FatherName");
            DropColumn("dbo.UserPersonalInfomations", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPersonalInfomations", "PhoneNumber", c => c.String());
            AddColumn("dbo.UserPersonalInfomations", "FatherName", c => c.String());
            AddColumn("dbo.UserPersonalInfomations", "Status", c => c.String());
            AddColumn("dbo.UserPersonalInfomations", "Address2", c => c.String());
            AddColumn("dbo.UserPersonalInfomations", "Address1", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "SubCommunityId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGeneralInfomations", "CommunityId", c => c.Int(nullable: false));
            DropColumn("dbo.UserGeneralInfomations", "PhoneNumber");
            DropColumn("dbo.UserGeneralInfomations", "FatherName");
            DropColumn("dbo.UserGeneralInfomations", "Status");
            DropColumn("dbo.UserGeneralInfomations", "Address2");
            DropColumn("dbo.UserGeneralInfomations", "Address1");
            CreateIndex("dbo.UserGeneralInfomations", "CommunityId");
            AddForeignKey("dbo.UserGeneralInfomations", "CommunityId", "dbo.Communities", "Id");
        }
    }
}
