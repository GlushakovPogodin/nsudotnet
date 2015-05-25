namespace CTNDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableCascadeOnCTN : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.IntercityConversations", new[] { "CTN_Id" });
            RenameColumn(table: "dbo.IntercityConversations", name: "CTN_Id", newName: "ExteriorCTNId");
            AlterColumn("dbo.IntercityConversations", "ExteriorCTNId", c => c.Int(nullable: false));
            CreateIndex("dbo.IntercityConversations", "ExteriorCTNId");
            DropColumn("dbo.IntercityConversations", "ExteriorCTN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IntercityConversations", "ExteriorCTN", c => c.Int(nullable: false));
            DropIndex("dbo.IntercityConversations", new[] { "ExteriorCTNId" });
            AlterColumn("dbo.IntercityConversations", "ExteriorCTNId", c => c.Int());
            RenameColumn(table: "dbo.IntercityConversations", name: "ExteriorCTNId", newName: "CTN_Id");
            CreateIndex("dbo.IntercityConversations", "CTN_Id");
        }
    }
}
