namespace LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                        TableName = c.String(),
                        columnName = c.String(),
                        RecordId = c.Int(nullable: false),
                        Event = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.licenses", t => t.LicenseId, cascadeDelete: true)
                .Index(t => t.LicenseId);
            
            CreateTable(
                "dbo.licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        AgentID = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        PlotNumber = c.String(),
                        Work = c.String(),
                        Fees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LicenseNumber = c.String(),
                        ValidityStatId = c.Int(),
                        EntryDate = c.DateTime(),
                        ExaminationFeeDate = c.DateTime(),
                        FeesPaymentDate = c.DateTime(),
                        SignatureDate = c.DateTime(),
                        ReceiveDate = c.DateTime(),
                        Notes = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.AgentID, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.ValidityStatments", t => t.ValidityStatId)
                .Index(t => t.OwnerID)
                .Index(t => t.AgentID)
                .Index(t => t.LocationId)
                .Index(t => t.ValidityStatId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NationalId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValidityStatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(),
                        InitialSupplyDate = c.DateTime(),
                        ValidatySupplyDate = c.DateTime(),
                        ReceiveDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "LicenseId", "dbo.licenses");
            DropForeignKey("dbo.licenses", "ValidityStatId", "dbo.ValidityStatments");
            DropForeignKey("dbo.licenses", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.licenses", "OwnerID", "dbo.Users");
            DropForeignKey("dbo.licenses", "AgentID", "dbo.Users");
            DropForeignKey("dbo.AdminLogs", "AdminId", "dbo.Admins");
            DropIndex("dbo.licenses", new[] { "ValidityStatId" });
            DropIndex("dbo.licenses", new[] { "LocationId" });
            DropIndex("dbo.licenses", new[] { "AgentID" });
            DropIndex("dbo.licenses", new[] { "OwnerID" });
            DropIndex("dbo.Fees", new[] { "LicenseId" });
            DropIndex("dbo.AdminLogs", new[] { "AdminId" });
            DropTable("dbo.ValidityStatments");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.licenses");
            DropTable("dbo.Fees");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminLogs");
        }
    }
}
