namespace CampusCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.student",
                c => new
                    {
                        stdID = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 150, unicode: false),
                        course = c.String(nullable: false, maxLength: 150, unicode: false),
                        year = c.String(nullable: false, maxLength: 150, unicode: false),
                        email = c.String(nullable: false, maxLength: 150, unicode: false),
                        mobile = c.String(nullable: false, maxLength: 150, unicode: false),
                        add_resume = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.stdID);
            
            CreateTable(
                "dbo.appliedstudentlist",
                c => new
                    {
                        apply_ID = c.Int(nullable: false, identity: true),
                        studentinfo = c.Int(nullable: false),
                        companyinfo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.apply_ID)
                .ForeignKey("dbo.company", t => t.companyinfo, cascadeDelete: true)
                .ForeignKey("dbo.student", t => t.studentinfo, cascadeDelete: true)
                .Index(t => t.studentinfo)
                .Index(t => t.companyinfo);
            
            CreateTable(
                "dbo.company",
                c => new
                    {
                        compID = c.Int(nullable: false, identity: true),
                        cmpname = c.String(nullable: false, maxLength: 150),
                        location = c.String(nullable: false, maxLength: 150),
                        job_requirements = c.Int(nullable: false),
                        job_description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.compID);
            
            CreateTable(
                "dbo.placed_student_list",
                c => new
                    {
                        place_ID = c.Int(nullable: false, identity: true),
                        stdID = c.Int(nullable: false),
                        compID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.place_ID)
                .ForeignKey("dbo.company", t => t.compID, cascadeDelete: true)
                .Index(t => t.compID);
            
            CreateTable(
                "dbo.roundpass",
                c => new
                    {
                        rp_ID = c.Int(nullable: false, identity: true),
                        stdID = c.Int(nullable: false),
                        compID = c.Int(nullable: false),
                        which_round_they_pass = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.rp_ID)
                .ForeignKey("dbo.company", t => t.compID, cascadeDelete: true)
                .Index(t => t.compID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.appliedstudentlist", "studentinfo", "dbo.student");
            DropForeignKey("dbo.appliedstudentlist", "companyinfo", "dbo.company");
            DropForeignKey("dbo.roundpass", "compID", "dbo.company");
            DropForeignKey("dbo.placed_student_list", "compID", "dbo.company");
            DropIndex("dbo.roundpass", new[] { "compID" });
            DropIndex("dbo.placed_student_list", new[] { "compID" });
            DropIndex("dbo.appliedstudentlist", new[] { "companyinfo" });
            DropIndex("dbo.appliedstudentlist", new[] { "studentinfo" });
            DropTable("dbo.roundpass");
            DropTable("dbo.placed_student_list");
            DropTable("dbo.company");
            DropTable("dbo.appliedstudentlist");
            DropTable("dbo.student");
        }
    }
}
