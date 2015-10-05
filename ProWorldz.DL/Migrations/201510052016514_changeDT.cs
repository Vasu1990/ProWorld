namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "CountryId", c => c.Int());
            AlterColumn("dbo.Employers", "LocationId", c => c.Int());
            AlterColumn("dbo.Employers", "IndustryId", c => c.Int());
            AlterColumn("dbo.Employers", "CompanyContactNumber", c => c.Int());
            AlterColumn("dbo.Employers", "UserPhoneNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "UserPhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Employers", "CompanyContactNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Employers", "IndustryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employers", "LocationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employers", "CountryId", c => c.Int(nullable: false));
        }
    }
}
