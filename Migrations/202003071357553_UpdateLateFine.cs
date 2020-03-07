namespace AssignmentT1809ELateFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLateFine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LateFines", "RollNumber", c => c.String(nullable: false));
            AlterColumn("dbo.LateFines", "SubmitTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LateFines", "SubmitTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LateFines", "RollNumber", c => c.String());
        }
    }
}
