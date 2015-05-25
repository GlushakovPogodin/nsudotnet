namespace CTNDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(),
                        District = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Flat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ATSId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        PhoneTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        SubscriberId = c.Int(nullable: false),
                        IntercityStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.ATS", t => t.ATSId, cascadeDelete: true)
                .ForeignKey("dbo.IntercityStatus", t => t.IntercityStatus_Id)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId, cascadeDelete: true)
                .Index(t => t.ATSId)
                .Index(t => t.AddressId)
                .Index(t => t.PhoneTypeId)
                .Index(t => t.SubscriberId)
                .Index(t => t.IntercityStatus_Id);
            
            CreateTable(
                "dbo.ATS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CTNId = c.Int(nullable: false),
                        ATSTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ATSTypes", t => t.ATSTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CTNs", t => t.CTNId, cascadeDelete: true)
                .Index(t => t.CTNId)
                .Index(t => t.ATSTypeId);
            
            CreateTable(
                "dbo.ATSTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTNs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IntercityConversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConversationDate = c.DateTime(nullable: false),
                        ExteriorCTN = c.Int(nullable: false),
                        PhoneId = c.Int(nullable: false),
                        CTN_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CTNs", t => t.CTN_Id)
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .Index(t => t.PhoneId)
                .Index(t => t.CTN_Id);
            
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BalanceChangeTypeId = c.Int(nullable: false),
                        BalanceChangeValue = c.Int(nullable: false),
                        BalanceDate = c.DateTime(nullable: false),
                        PhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalanceChangeTypes", t => t.BalanceChangeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .Index(t => t.BalanceChangeTypeId)
                .Index(t => t.PhoneId);
            
            CreateTable(
                "dbo.BalanceChangeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IntercityStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Sex = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        SubscriberTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubscriberTypes", t => t.SubscriberTypeId, cascadeDelete: true)
                .Index(t => t.SubscriberTypeId);
            
            CreateTable(
                "dbo.SubscriberTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.String(),
                        QueueTypeId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.QueueTypes", t => t.QueueTypeId, cascadeDelete: true)
                .Index(t => t.QueueTypeId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.QueueTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Queues", "QueueTypeId", "dbo.QueueTypes");
            DropForeignKey("dbo.Queues", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Subscribers", "SubscriberTypeId", "dbo.SubscriberTypes");
            DropForeignKey("dbo.Phones", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.Phones", "PhoneTypeId", "dbo.PhoneTypes");
            DropForeignKey("dbo.Phones", "IntercityStatus_Id", "dbo.IntercityStatus");
            DropForeignKey("dbo.Balances", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Balances", "BalanceChangeTypeId", "dbo.BalanceChangeTypes");
            DropForeignKey("dbo.Phones", "ATSId", "dbo.ATS");
            DropForeignKey("dbo.IntercityConversations", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.IntercityConversations", "CTN_Id", "dbo.CTNs");
            DropForeignKey("dbo.ATS", "CTNId", "dbo.CTNs");
            DropForeignKey("dbo.ATS", "ATSTypeId", "dbo.ATSTypes");
            DropForeignKey("dbo.Phones", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Queues", new[] { "AddressId" });
            DropIndex("dbo.Queues", new[] { "QueueTypeId" });
            DropIndex("dbo.Subscribers", new[] { "SubscriberTypeId" });
            DropIndex("dbo.Balances", new[] { "PhoneId" });
            DropIndex("dbo.Balances", new[] { "BalanceChangeTypeId" });
            DropIndex("dbo.IntercityConversations", new[] { "CTN_Id" });
            DropIndex("dbo.IntercityConversations", new[] { "PhoneId" });
            DropIndex("dbo.ATS", new[] { "ATSTypeId" });
            DropIndex("dbo.ATS", new[] { "CTNId" });
            DropIndex("dbo.Phones", new[] { "IntercityStatus_Id" });
            DropIndex("dbo.Phones", new[] { "SubscriberId" });
            DropIndex("dbo.Phones", new[] { "PhoneTypeId" });
            DropIndex("dbo.Phones", new[] { "AddressId" });
            DropIndex("dbo.Phones", new[] { "ATSId" });
            DropTable("dbo.QueueTypes");
            DropTable("dbo.Queues");
            DropTable("dbo.SubscriberTypes");
            DropTable("dbo.Subscribers");
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.IntercityStatus");
            DropTable("dbo.BalanceChangeTypes");
            DropTable("dbo.Balances");
            DropTable("dbo.IntercityConversations");
            DropTable("dbo.CTNs");
            DropTable("dbo.ATSTypes");
            DropTable("dbo.ATS");
            DropTable("dbo.Phones");
            DropTable("dbo.Addresses");
        }
    }
}
