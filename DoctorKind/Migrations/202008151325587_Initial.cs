namespace DoctorKind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SpecializationId = c.Long(nullable: false),
                        UserId = c.String(maxLength: 128),
                        DoctorId = c.Long(nullable: false),
                        AppointmentType = c.Int(nullable: false),
                        Timing = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .ForeignKey("dbo.AppointmentTypes", t => t.AppointmentType, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.SpecializationId)
                .Index(t => t.UserId)
                .Index(t => t.DoctorId)
                .Index(t => t.AppointmentType);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNumber = c.String(),
                        Qualification = c.String(),
                        Description = c.String(),
                        EmailId = c.String(),
                        RegistrationNo = c.String(),
                        DoctorImage = c.String(),
                        RelevantDocument = c.String(),
                        SubscriptionStatus = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        WorkingDays = c.String(),
                        ApprovalStatus = c.String(),
                        UserId = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Clinic_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.Clinic_Id)
                .Index(t => t.Clinic_Id);
            
            CreateTable(
                "dbo.DoctorSpecializations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VideoConsulationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AudioConsultationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChatConsultationFree = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        SpecializationId = c.Long(nullable: false),
                        Status = c.String(),
                        Remarks = c.String(),
                        DoctorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        OTP = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        PinCode = c.String(),
                        EmailID = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DoctorId = c.Long(nullable: false),
                        ClinicName = c.String(),
                        Address = c.String(),
                        ClinicImages = c.String(),
                        Timings = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        DoctorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.AppImages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        ItemType = c.Int(nullable: false),
                        ItemId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemTypes", t => t.ItemType, cascadeDelete: true)
                .Index(t => t.ItemType);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.String(),
                        PaymentId = c.String(),
                        AppointmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Payments", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.AppImages", "ItemType", "dbo.ItemTypes");
            DropForeignKey("dbo.Documents", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Clinic_Id", "dbo.Clinics");
            DropForeignKey("dbo.Appointments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "AppointmentType", "dbo.AppointmentTypes");
            DropForeignKey("dbo.Appointments", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorSpecializations", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.DoctorSpecializations", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payments", new[] { "AppointmentId" });
            DropIndex("dbo.AppImages", new[] { "ItemType" });
            DropIndex("dbo.Documents", new[] { "DoctorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.DoctorSpecializations", new[] { "DoctorId" });
            DropIndex("dbo.DoctorSpecializations", new[] { "SpecializationId" });
            DropIndex("dbo.Doctors", new[] { "Clinic_Id" });
            DropIndex("dbo.Appointments", new[] { "AppointmentType" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "SpecializationId" });
            DropTable("dbo.WishLists");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.AppImages");
            DropTable("dbo.Documents");
            DropTable("dbo.Clinics");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Profiles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AppointmentTypes");
            DropTable("dbo.Specializations");
            DropTable("dbo.DoctorSpecializations");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
