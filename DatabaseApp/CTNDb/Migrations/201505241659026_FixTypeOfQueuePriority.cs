namespace CTNDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypeOfQueuePriority : DbMigration
    {
        public override void Up()
        {
            AlterColumn("CTNDb.Queue", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("CTNDb.Queue", "Priority", c => c.String());
        }
    }
}
