namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testooo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "HRManager_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "Line1Manager_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "Line2Manager_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Leaves", "AproovalHR_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "HRManager_Id");
            CreateIndex("dbo.Employees", "Line1Manager_Id");
            CreateIndex("dbo.Employees", "Line2Manager_Id");
            CreateIndex("dbo.Leaves", "AproovalHR_Id");
            AddForeignKey("dbo.Employees", "HRManager_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "Line1Manager_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "Line2Manager_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Leaves", "AproovalHR_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "AproovalHR_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Line2Manager_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Line1Manager_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "HRManager_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Leaves", new[] { "AproovalHR_Id" });
            DropIndex("dbo.Employees", new[] { "Line2Manager_Id" });
            DropIndex("dbo.Employees", new[] { "Line1Manager_Id" });
            DropIndex("dbo.Employees", new[] { "HRManager_Id" });
            DropColumn("dbo.Leaves", "AproovalHR_Id");
            DropColumn("dbo.Employees", "Line2Manager_Id");
            DropColumn("dbo.Employees", "Line1Manager_Id");
            DropColumn("dbo.Employees", "HRManager_Id");
        }
    }
}
