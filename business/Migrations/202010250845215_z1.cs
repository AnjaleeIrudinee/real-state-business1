namespace business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class z1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_tbl",
                c => new
                    {
                        BranchNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.BranchNo);
            
            CreateTable(
                "dbo.Owner_tbl",
                c => new
                    {
                        OwnerNo = c.String(nullable: false, maxLength: 128),
                        OwnerFname = c.String(),
                        OwnerLname = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerNo);
            
            CreateTable(
                "dbo.Rent_tbl",
                c => new
                    {
                        PropertyNo = c.String(nullable: false, maxLength: 128),
                        PropertyStreet = c.String(),
                        City = c.String(),
                        Ptype = c.String(),
                        Rooms = c.Int(nullable: false),
                        OwnerNo_Ref = c.String(maxLength: 128),
                        StaffNo_Ref = c.String(maxLength: 128),
                        BranchNo_Ref = c.String(maxLength: 128),
                        rent1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchNo_Ref)
                .ForeignKey("dbo.Owner_tbl", t => t.OwnerNo_Ref)
                .ForeignKey("dbo.Staff_tbl", t => t.StaffNo_Ref)
                .Index(t => t.OwnerNo_Ref)
                .Index(t => t.StaffNo_Ref)
                .Index(t => t.BranchNo_Ref);
            
            CreateTable(
                "dbo.Staff_tbl",
                c => new
                    {
                        StaffNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Int(nullable: false),
                        BranchNo_Ref = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchNo_Ref)
                .Index(t => t.BranchNo_Ref);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent_tbl", "StaffNo_Ref", "dbo.Staff_tbl");
            DropForeignKey("dbo.Staff_tbl", "BranchNo_Ref", "dbo.Branch_tbl");
            DropForeignKey("dbo.Rent_tbl", "OwnerNo_Ref", "dbo.Owner_tbl");
            DropForeignKey("dbo.Rent_tbl", "BranchNo_Ref", "dbo.Branch_tbl");
            DropIndex("dbo.Staff_tbl", new[] { "BranchNo_Ref" });
            DropIndex("dbo.Rent_tbl", new[] { "BranchNo_Ref" });
            DropIndex("dbo.Rent_tbl", new[] { "StaffNo_Ref" });
            DropIndex("dbo.Rent_tbl", new[] { "OwnerNo_Ref" });
            DropTable("dbo.Staff_tbl");
            DropTable("dbo.Rent_tbl");
            DropTable("dbo.Owner_tbl");
            DropTable("dbo.Branch_tbl");
        }
    }
}
