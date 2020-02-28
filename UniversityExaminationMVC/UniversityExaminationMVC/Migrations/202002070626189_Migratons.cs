namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculties", "DOB", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faculties", "DOB");
        }
    }
}
