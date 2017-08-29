namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personalinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sex = c.String(),
                        MaterialStatus = c.String(),
                        HusbandOrSpouse = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        PlaceOfBirth = c.String(),
                        AdharNumber = c.String(),
                        Nationality = c.String(nullable: false),
                        MotherTounge = c.String(),
                        PasspostNumber = c.String(),
                        ImageURL = c.String(),
                        Relagion = c.String(),
                        EmergencyContact = c.String(),
                        EmergencyPhone = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Pin = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Departments", "Organization_Id", c => c.Int());
            AddColumn("dbo.Employees", "Organization_Id", c => c.Int());
            CreateIndex("dbo.Departments", "Organization_Id");
            CreateIndex("dbo.Employees", "Organization_Id");
            AddForeignKey("dbo.Departments", "Organization_Id", "dbo.Organizations", "Id");
            AddForeignKey("dbo.Employees", "Organization_Id", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInfoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Departments", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonalInfoes", new[] { "User_Id" });
            DropIndex("dbo.Employees", new[] { "Organization_Id" });
            DropIndex("dbo.Departments", new[] { "Organization_Id" });
            DropColumn("dbo.Employees", "Organization_Id");
            DropColumn("dbo.Departments", "Organization_Id");
            DropTable("dbo.PersonalInfoes");
        }
    }
}
