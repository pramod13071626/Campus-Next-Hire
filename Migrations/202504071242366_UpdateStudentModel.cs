namespace CampusCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.company", "job_requirements", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.company", "job_requirements", c => c.Int(nullable: false));
        }
    }
}
