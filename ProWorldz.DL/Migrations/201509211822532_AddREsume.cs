namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddREsume : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterModuleTypeDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        ModuleTypeId = c.Int(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserResumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsVisaHolder = c.Boolean(nullable: false),
                        IsForeignWorker = c.Boolean(nullable: false),
                        TotalExperience = c.String(),
                        ResumePath = c.String(),
                        CoverLetterPath = c.String(),
                        ResumeContent = c.String(),
                        CoverLetterContent = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResumes", "UserId", "dbo.Users");
            DropIndex("dbo.UserResumes", new[] { "UserId" });
            DropTable("dbo.UserResumes");
            DropTable("dbo.MasterModuleTypeDatas");
        }
    }
}
