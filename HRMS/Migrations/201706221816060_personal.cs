namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Pin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "CurrentAddress_Id", c => c.Int());
            AddColumn("dbo.PersonalInfoes", "PermanentAddress_Id", c => c.Int());
            CreateIndex("dbo.Employees", "CurrentAddress_Id");
            CreateIndex("dbo.PersonalInfoes", "PermanentAddress_Id");
            AddForeignKey("dbo.Employees", "CurrentAddress_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.PersonalInfoes", "PermanentAddress_Id", "dbo.Addresses", "Id");
            DropColumn("dbo.Employees", "AddressLine1");
            DropColumn("dbo.Employees", "AddressLine2");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Pin");
            DropColumn("dbo.PersonalInfoes", "AddressLine1");
            DropColumn("dbo.PersonalInfoes", "AddressLine2");
            DropColumn("dbo.PersonalInfoes", "City");
            DropColumn("dbo.PersonalInfoes", "Pin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalInfoes", "Pin", c => c.String());
            AddColumn("dbo.PersonalInfoes", "City", c => c.String());
            AddColumn("dbo.PersonalInfoes", "AddressLine2", c => c.String());
            AddColumn("dbo.PersonalInfoes", "AddressLine1", c => c.String());
            AddColumn("dbo.Employees", "Pin", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "AddressLine2", c => c.String());
            AddColumn("dbo.Employees", "AddressLine1", c => c.String());
            DropForeignKey("dbo.PersonalInfoes", "PermanentAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Employees", "CurrentAddress_Id", "dbo.Addresses");
            DropIndex("dbo.PersonalInfoes", new[] { "PermanentAddress_Id" });
            DropIndex("dbo.Employees", new[] { "CurrentAddress_Id" });
            DropColumn("dbo.PersonalInfoes", "PermanentAddress_Id");
            DropColumn("dbo.Employees", "CurrentAddress_Id");
            DropTable("dbo.Addresses");
        }
    }
}
