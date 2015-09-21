namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPostType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPosts", "PostType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPosts", "PostType");
        }
    }
}
