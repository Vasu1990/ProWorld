namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isUserOnlineFalg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsOnline", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsOnline");
        }
    }
}
