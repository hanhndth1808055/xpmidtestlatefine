namespace AssignmentT1809ELateFine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LateFines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(),
                        DisciplineType = c.Int(nullable: false),
                        DisciplineAmount = c.Double(nullable: false),
                        SubmitTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.LateFines");
        }
    }
}
