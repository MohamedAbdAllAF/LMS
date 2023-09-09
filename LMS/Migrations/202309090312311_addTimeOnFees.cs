namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeOnFees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fees", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fees", "CreatedOn");
        }
    }
}
