namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCurrentJobField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfessionalQualifications", "IsCurrentJob", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserQualifications", "Specialization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQualifications", "Specialization");
            DropColumn("dbo.UserProfessionalQualifications", "IsCurrentJob");
        }
    }
}
