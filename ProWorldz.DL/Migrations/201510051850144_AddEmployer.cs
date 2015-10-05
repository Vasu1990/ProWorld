namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        CountryId = c.Int(nullable: false),
                        CompanyName = c.String(maxLength: 100),
                        Website = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                        LocationId = c.Int(nullable: false),
                        IndustryId = c.Int(nullable: false),
                        CompanyExtentionNumber = c.String(),
                        Address = c.String(),
                        CompanyContactNumber = c.Int(nullable: false),
                        Username = c.String(maxLength: 100),
                        Designation = c.String(),
                        UserPhoneNumber = c.Int(nullable: false),
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
            DropTable("dbo.Employers");
        }
    }
}
