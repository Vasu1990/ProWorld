namespace ProWorldz.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27AugChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Message = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Lkp_FriendShipStatus", t => t.FriendShipStatusId)
                .Index(t => t.UserId)
                .Index(t => t.FriendShipStatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        CommunityId = c.Int(nullable: false),
                        SubCommunityId = c.Int(nullable: false),
                        CommunityName = c.String(),
                        SubCommunityName = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.UserGeneralInfomations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Status = c.String(),
                        FatherName = c.String(),
                        PhoneNumber = c.String(),
                        UserId = c.Int(nullable: false),
                        Image = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Lkp_FriendShipStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndustryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPersonalInfomations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Subject = c.String(),
                        Post = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Comment = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.UserPosts", t => t.PostId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.UserProfessionalQualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Designation = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCurrentEmployee = c.Boolean(nullable: false),
                        CurrentIndustry = c.Int(nullable: false),
                        UserRole = c.String(),
                        Skill = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndustryTypes", t => t.CurrentIndustry)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CurrentIndustry);
            
            CreateTable(
                "dbo.UserQualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SchoolName = c.String(),
                        DegreeName = c.Int(nullable: false),
                        Percentage = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeName)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DegreeName);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserVideos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        VideoResumeUrl = c.String(),
                        ArtWorkYouTube1 = c.String(),
                        ArtWorkYouTube2 = c.String(),
                        ArtWorkYouTube3 = c.String(),
                        ArtWorkYouTube4 = c.String(),
                        ArtWorkYouTube5 = c.String(),
                        ArtWorkUrl1 = c.String(),
                        ArtWorkUrl2 = c.String(),
                        ArtWorkUrl3 = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVideos", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserQualifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserQualifications", "DegreeName", "dbo.Degrees");
            DropForeignKey("dbo.UserProfessionalQualifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProfessionalQualifications", "CurrentIndustry", "dbo.IndustryTypes");
            DropForeignKey("dbo.UserPostComments", "PostId", "dbo.UserPosts");
            DropForeignKey("dbo.UserPostComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPersonalInfomations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendShipStatusId", "dbo.Lkp_FriendShipStatus");
            DropForeignKey("dbo.UserGeneralInfomations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "StateId", "dbo.States");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropIndex("dbo.UserVideos", new[] { "UserId" });
            DropIndex("dbo.UserQualifications", new[] { "DegreeName" });
            DropIndex("dbo.UserQualifications", new[] { "UserId" });
            DropIndex("dbo.UserProfessionalQualifications", new[] { "CurrentIndustry" });
            DropIndex("dbo.UserProfessionalQualifications", new[] { "UserId" });
            DropIndex("dbo.UserPostComments", new[] { "PostId" });
            DropIndex("dbo.UserPostComments", new[] { "UserId" });
            DropIndex("dbo.UserPosts", new[] { "UserId" });
            DropIndex("dbo.UserPersonalInfomations", new[] { "UserId" });
            DropIndex("dbo.UserGeneralInfomations", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "StateId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Friends", new[] { "FriendShipStatusId" });
            DropIndex("dbo.Friends", new[] { "UserId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropTable("dbo.UserVideos");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserQualifications");
            DropTable("dbo.UserProfessionalQualifications");
            DropTable("dbo.UserPostComments");
            DropTable("dbo.UserPosts");
            DropTable("dbo.UserPersonalInfomations");
            DropTable("dbo.IndustryTypes");
            DropTable("dbo.Lkp_FriendShipStatus");
            DropTable("dbo.UserGeneralInfomations");
            DropTable("dbo.Users");
            DropTable("dbo.Friends");
            DropTable("dbo.Degrees");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Communities");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
