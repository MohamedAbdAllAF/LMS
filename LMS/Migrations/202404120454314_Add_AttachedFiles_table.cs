namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AttachedFiles_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttachedFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileExtension = c.String(),
                        FileData = c.Binary(),
                        LicenseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.licenses", t => t.LicenseId, cascadeDelete: true)
                .Index(t => t.LicenseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttachedFiles", "LicenseId", "dbo.licenses");
            DropIndex("dbo.AttachedFiles", new[] { "LicenseId" });
            DropTable("dbo.AttachedFiles");
        }
    }
}
