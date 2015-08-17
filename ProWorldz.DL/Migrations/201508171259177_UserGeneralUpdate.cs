namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGeneralUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGeneralInfomations", "Address1", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "Address2", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "Status", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "FatherName", c => c.String());
            AddColumn("dbo.UserGeneralInfomations", "PhoneNumber", c => c.String());
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
            DropColumn("dbo.UserGeneralInfomations", "PhoneNumber");
            DropColumn("dbo.UserGeneralInfomations", "FatherName");
            DropColumn("dbo.UserGeneralInfomations", "Status");
            DropColumn("dbo.UserGeneralInfomations", "Address2");
            DropColumn("dbo.UserGeneralInfomations", "Address1");
        }
    }
}
