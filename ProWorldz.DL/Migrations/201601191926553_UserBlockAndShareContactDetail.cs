namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserBlockAndShareContactDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShareContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentUserId = c.Int(nullable: false),
                        ShareUserId = c.Int(nullable: false),
                        Message = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentUserId = c.Int(nullable: false),
                        ShareUserId = c.Int(nullable: false),
                        IsBlock = c.Boolean(nullable: false),
                        IsFollow = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserBlocks");
            DropTable("dbo.ShareContactDetails");
        }
    }
}
