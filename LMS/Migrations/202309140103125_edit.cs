namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.licenses", "InitialSupplyDate", c => c.DateTime());
            AddColumn("dbo.licenses", "FinalPaymentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.licenses", "FinalPaymentDate");
            DropColumn("dbo.licenses", "InitialSupplyDate");
        }
    }
}
