namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactusdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUs", "CreationDate");
        }
    }
}
