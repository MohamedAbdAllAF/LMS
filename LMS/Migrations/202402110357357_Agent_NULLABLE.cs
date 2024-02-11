namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agent_NULLABLE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.licenses", "AgentID", "dbo.Users");
            DropIndex("dbo.licenses", new[] { "AgentID" });
            AlterColumn("dbo.licenses", "AgentID", c => c.Int());
            CreateIndex("dbo.licenses", "AgentID");
            AddForeignKey("dbo.licenses", "AgentID", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.licenses", "AgentID", "dbo.Users");
            DropIndex("dbo.licenses", new[] { "AgentID" });
            AlterColumn("dbo.licenses", "AgentID", c => c.Int(nullable: false));
            CreateIndex("dbo.licenses", "AgentID");
            AddForeignKey("dbo.licenses", "AgentID", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
