namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class friends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        FriendShipStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lkp_FriendShipStatus", t => t.FriendShipStatusId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FriendShipStatusId);
            
            CreateTable(
                "dbo.Lkp_FriendShipStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendShipStatusId", "dbo.Lkp_FriendShipStatus");
            DropIndex("dbo.Friends", new[] { "FriendShipStatusId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropTable("dbo.Lkp_FriendShipStatus");
            DropTable("dbo.Friends");
        }
    }
}
