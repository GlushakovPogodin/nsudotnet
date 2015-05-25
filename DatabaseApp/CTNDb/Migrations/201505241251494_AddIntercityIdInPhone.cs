namespace CTNDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntercityIdInPhone : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "Address");
            RenameTable(name: "dbo.Phones", newName: "Phone");
            RenameTable(name: "dbo.ATSTypes", newName: "ATSType");
            RenameTable(name: "dbo.CTNs", newName: "CTN");
            RenameTable(name: "dbo.IntercityConversations", newName: "IntercityConversation");
            RenameTable(name: "dbo.Balances", newName: "Balance");
            RenameTable(name: "dbo.BalanceChangeTypes", newName: "BalanceChangeType");
            RenameTable(name: "dbo.PhoneTypes", newName: "PhoneType");
            RenameTable(name: "dbo.Subscribers", newName: "Subscriber");
            RenameTable(name: "dbo.SubscriberTypes", newName: "SubscriberType");
            RenameTable(name: "dbo.Queues", newName: "Queue");
            RenameTable(name: "dbo.QueueTypes", newName: "QueueType");
            MoveTable(name: "dbo.Address", newSchema: "CTNDb");
            MoveTable(name: "dbo.Phone", newSchema: "CTNDb");
            MoveTable(name: "dbo.ATS", newSchema: "CTNDb");
            MoveTable(name: "dbo.ATSType", newSchema: "CTNDb");
            MoveTable(name: "dbo.CTN", newSchema: "CTNDb");
            MoveTable(name: "dbo.IntercityConversation", newSchema: "CTNDb");
            MoveTable(name: "dbo.Balance", newSchema: "CTNDb");
            MoveTable(name: "dbo.BalanceChangeType", newSchema: "CTNDb");
            MoveTable(name: "dbo.IntercityStatus", newSchema: "CTNDb");
            MoveTable(name: "dbo.PhoneType", newSchema: "CTNDb");
            MoveTable(name: "dbo.Subscriber", newSchema: "CTNDb");
            MoveTable(name: "dbo.SubscriberType", newSchema: "CTNDb");
            MoveTable(name: "dbo.Queue", newSchema: "CTNDb");
            MoveTable(name: "dbo.QueueType", newSchema: "CTNDb");
            DropForeignKey("dbo.Phones", "IntercityStatus_Id", "dbo.IntercityStatus");
            DropIndex("CTNDb.Phone", new[] { "IntercityStatus_Id" });
            RenameColumn(table: "CTNDb.Phone", name: "IntercityStatus_Id", newName: "IntercityStatusId");
            AlterColumn("CTNDb.Phone", "IntercityStatusId", c => c.Int(nullable: false));
            CreateIndex("CTNDb.Phone", "IntercityStatusId");
            AddForeignKey("CTNDb.Phone", "IntercityStatusId", "CTNDb.IntercityStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("CTNDb.Phone", "IntercityStatusId", "CTNDb.IntercityStatus");
            DropIndex("CTNDb.Phone", new[] { "IntercityStatusId" });
            AlterColumn("CTNDb.Phone", "IntercityStatusId", c => c.Int());
            RenameColumn(table: "CTNDb.Phone", name: "IntercityStatusId", newName: "IntercityStatus_Id");
            CreateIndex("CTNDb.Phone", "IntercityStatus_Id");
            AddForeignKey("dbo.Phones", "IntercityStatus_Id", "dbo.IntercityStatus", "Id");
            MoveTable(name: "CTNDb.QueueType", newSchema: "dbo");
            MoveTable(name: "CTNDb.Queue", newSchema: "dbo");
            MoveTable(name: "CTNDb.SubscriberType", newSchema: "dbo");
            MoveTable(name: "CTNDb.Subscriber", newSchema: "dbo");
            MoveTable(name: "CTNDb.PhoneType", newSchema: "dbo");
            MoveTable(name: "CTNDb.IntercityStatus", newSchema: "dbo");
            MoveTable(name: "CTNDb.BalanceChangeType", newSchema: "dbo");
            MoveTable(name: "CTNDb.Balance", newSchema: "dbo");
            MoveTable(name: "CTNDb.IntercityConversation", newSchema: "dbo");
            MoveTable(name: "CTNDb.CTN", newSchema: "dbo");
            MoveTable(name: "CTNDb.ATSType", newSchema: "dbo");
            MoveTable(name: "CTNDb.ATS", newSchema: "dbo");
            MoveTable(name: "CTNDb.Phone", newSchema: "dbo");
            MoveTable(name: "CTNDb.Address", newSchema: "dbo");
            RenameTable(name: "dbo.QueueType", newName: "QueueTypes");
            RenameTable(name: "dbo.Queue", newName: "Queues");
            RenameTable(name: "dbo.SubscriberType", newName: "SubscriberTypes");
            RenameTable(name: "dbo.Subscriber", newName: "Subscribers");
            RenameTable(name: "dbo.PhoneType", newName: "PhoneTypes");
            RenameTable(name: "dbo.BalanceChangeType", newName: "BalanceChangeTypes");
            RenameTable(name: "dbo.Balance", newName: "Balances");
            RenameTable(name: "dbo.IntercityConversation", newName: "IntercityConversations");
            RenameTable(name: "dbo.CTN", newName: "CTNs");
            RenameTable(name: "dbo.ATSType", newName: "ATSTypes");
            RenameTable(name: "dbo.Phone", newName: "Phones");
            RenameTable(name: "dbo.Address", newName: "Addresses");
        }
    }
}
