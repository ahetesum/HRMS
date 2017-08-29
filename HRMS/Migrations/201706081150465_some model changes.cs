namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somemodelchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Customers", new[] { "Contact_Id" });
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Pin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClaimRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Satus = c.String(),
                        ClaimDate = c.DateTime(nullable: false),
                        Priority = c.String(),
                        AproovalManagaer_Id = c.String(maxLength: 128),
                        Claim_Id = c.Int(),
                        RequestedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AproovalManagaer_Id)
                .ForeignKey("dbo.Claims", t => t.Claim_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestedBy_Id)
                .Index(t => t.AproovalManagaer_Id)
                .Index(t => t.Claim_Id)
                .Index(t => t.RequestedBy_Id);
            
            CreateTable(
                "dbo.SalaryStacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasicPay = c.String(),
                        HomeAllowence = c.String(),
                        TravelAllowence = c.String(),
                        VariablePay = c.String(),
                        BenifitPlan = c.String(),
                        ProvidentFund = c.String(),
                        Gratuty = c.String(),
                        HealthBenifit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assets", "Description", c => c.String());
            AddColumn("dbo.Assets", "Brand", c => c.String());
            AddColumn("dbo.Assets", "Vendor_Id", c => c.Int());
            AddColumn("dbo.Claims", "Name", c => c.String());
            AddColumn("dbo.Claims", "Code", c => c.String());
            AddColumn("dbo.Claims", "Value", c => c.String());
            AddColumn("dbo.Claims", "Brand", c => c.String());
            AddColumn("dbo.Departments", "Description", c => c.String());
            AddColumn("dbo.Employees", "AddressLine1", c => c.String());
            AddColumn("dbo.Employees", "AddressLine2", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "Pin", c => c.String());
            AddColumn("dbo.Employees", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Leaves", "AproovalManagaer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "Description", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "Pin", c => c.String());
            AddColumn("dbo.Customers", "Host_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Assets", "Vendor_Id");
            CreateIndex("dbo.Employees", "User_Id");
            CreateIndex("dbo.Leaves", "AproovalManagaer_Id");
            CreateIndex("dbo.Customers", "Host_Id");
            AddForeignKey("dbo.Assets", "Vendor_Id", "dbo.Vendors", "Id");
            AddForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Leaves", "AproovalManagaer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "Host_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Claims", "Title");
            DropColumn("dbo.Claims", "ClaimDate");
            DropColumn("dbo.Customers", "Contact_Id");
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Designation = c.String(),
                        PrimaryPhone = c.String(),
                        SecondaryPhone = c.String(),
                        PrimaryEmail = c.String(),
                        SecondaryEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Contact_Id", c => c.Int());
            AddColumn("dbo.Claims", "ClaimDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Claims", "Title", c => c.String());
            DropForeignKey("dbo.Customers", "Host_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leaves", "AproovalManagaer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClaimRequests", "RequestedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClaimRequests", "Claim_Id", "dbo.Claims");
            DropForeignKey("dbo.ClaimRequests", "AproovalManagaer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Assets", "Vendor_Id", "dbo.Vendors");
            DropIndex("dbo.Customers", new[] { "Host_Id" });
            DropIndex("dbo.Leaves", new[] { "AproovalManagaer_Id" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.ClaimRequests", new[] { "RequestedBy_Id" });
            DropIndex("dbo.ClaimRequests", new[] { "Claim_Id" });
            DropIndex("dbo.ClaimRequests", new[] { "AproovalManagaer_Id" });
            DropIndex("dbo.Assets", new[] { "Vendor_Id" });
            DropColumn("dbo.Customers", "Host_Id");
            DropColumn("dbo.Customers", "Pin");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Description");
            DropColumn("dbo.Leaves", "AproovalManagaer_Id");
            DropColumn("dbo.Employees", "User_Id");
            DropColumn("dbo.Employees", "Pin");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "AddressLine2");
            DropColumn("dbo.Employees", "AddressLine1");
            DropColumn("dbo.Departments", "Description");
            DropColumn("dbo.Claims", "Brand");
            DropColumn("dbo.Claims", "Value");
            DropColumn("dbo.Claims", "Code");
            DropColumn("dbo.Claims", "Name");
            DropColumn("dbo.Assets", "Vendor_Id");
            DropColumn("dbo.Assets", "Brand");
            DropColumn("dbo.Assets", "Description");
            DropTable("dbo.SalaryStacks");
            DropTable("dbo.ClaimRequests");
            DropTable("dbo.Vendors");
            CreateIndex("dbo.Customers", "Contact_Id");
            AddForeignKey("dbo.Customers", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
