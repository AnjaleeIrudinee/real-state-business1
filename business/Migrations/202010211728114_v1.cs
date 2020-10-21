namespace business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.BranchNo);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerNo = c.String(nullable: false, maxLength: 128),
                        OwnerFname = c.String(),
                        OwnerLname = c.String(),
                        Address = c.String(),
                        TelNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerNo);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        RefBranchNo = c.String(maxLength: 128),
                        Owner_OwnerNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNo)
                .ForeignKey("dbo.Branches", t => t.RefBranchNo)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerNo)
                .Index(t => t.RefBranchNo)
                .Index(t => t.Owner_OwnerNo);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        PropertyNo = c.String(nullable: false, maxLength: 128),
                        PropertyStreet = c.String(),
                        Street = c.String(),
                        Ptype = c.String(),
                        Rooms = c.Int(nullable: false),
                        OwnerNo_Ref = c.String(maxLength: 128),
                        StaffNo_Ref = c.String(maxLength: 128),
                        BranchNo_Ref = c.String(maxLength: 128),
                        rent1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyNo)
                .ForeignKey("dbo.Branches", t => t.BranchNo_Ref)
                .ForeignKey("dbo.Owners", t => t.OwnerNo_Ref)
                .ForeignKey("dbo.Staffs", t => t.StaffNo_Ref)
                .Index(t => t.OwnerNo_Ref)
                .Index(t => t.StaffNo_Ref)
                .Index(t => t.BranchNo_Ref);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "StaffNo_Ref", "dbo.Staffs");
            DropForeignKey("dbo.Rents", "OwnerNo_Ref", "dbo.Owners");
            DropForeignKey("dbo.Rents", "BranchNo_Ref", "dbo.Branches");
            DropForeignKey("dbo.Staffs", "Owner_OwnerNo", "dbo.Owners");
            DropForeignKey("dbo.Staffs", "RefBranchNo", "dbo.Branches");
            DropIndex("dbo.Rents", new[] { "BranchNo_Ref" });
            DropIndex("dbo.Rents", new[] { "StaffNo_Ref" });
            DropIndex("dbo.Rents", new[] { "OwnerNo_Ref" });
            DropIndex("dbo.Staffs", new[] { "Owner_OwnerNo" });
            DropIndex("dbo.Staffs", new[] { "RefBranchNo" });
            DropTable("dbo.Rents");
            DropTable("dbo.Staffs");
            DropTable("dbo.Owners");
            DropTable("dbo.Branches");
        }
    }
}
