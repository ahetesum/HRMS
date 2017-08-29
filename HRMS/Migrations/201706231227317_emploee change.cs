namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emploeechange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "DeskLocation", c => c.String());
            AddColumn("dbo.Employees", "Department_Id", c => c.Int());
            AddColumn("dbo.Employees", "Designation_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Department_Id");
            CreateIndex("dbo.Employees", "Designation_Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Employees", "Designation_Id", "dbo.Positions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Designation_Id", "dbo.Positions");
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Designation_Id" });
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropColumn("dbo.Employees", "Designation_Id");
            DropColumn("dbo.Employees", "Department_Id");
            DropColumn("dbo.Employees", "DeskLocation");
            DropTable("dbo.Positions");
        }
    }
}
