namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewJobField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployerId = c.Int(nullable: false),
                        Headline = c.String(maxLength: 200),
                        Designation = c.String(),
                        JobRole = c.String(),
                        JobSkill = c.String(),
                        JobFunction = c.String(),
                        CountryId = c.Int(),
                        StateId = c.Int(),
                        CityId = c.Int(),
                        CommunityId = c.Int(),
                        SubCommunityId = c.Int(),
                        EducationQualification = c.String(),
                        ExpYear = c.String(),
                        ExpMonth = c.String(),
                        IndustryId = c.Int(),
                        SalaryLakhs = c.String(),
                        SalaryThousands = c.String(),
                        JobDescription = c.String(),
                        PostingDate = c.DateTime(nullable: false),
                        DateOfAdvExp = c.DateTime(nullable: false),
                        Email = c.String(),
                        ContactPerson = c.String(),
                        EmployementType = c.String(),
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
            DropTable("dbo.Jobs");
        }
    }
}
