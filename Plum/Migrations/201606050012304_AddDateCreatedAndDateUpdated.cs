namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCreatedAndDateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("Businesses", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("Businesses", "DateUpdated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));

            AddColumn("Queues", "DateCreated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
            AddColumn("Queues", "DateUpdated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));

            RenameColumn("Customers", "DateAdded", "DateCreated");
            AddColumn("Customers", "DateUpdated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));

            RenameColumn("CustomerLogEntries", "DateInserted", "DateCreated");
            AddColumn("CustomerLogEntries", "DateUpdated", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("Businesses", "DateCreated");
            DropColumn("Businesses", "DateUpdated");

            DropColumn("Queues", "DateCreated");
            DropColumn("Queues", "DateUpdated");

            RenameColumn("Customers", "DateCreated", "DateAdded");
            DropColumn("Customers", "DateUpdated");

            RenameColumn("CustomerLogEntries", "DateCreated", "DateInserted");
            DropColumn("CustomerLogEntries", "DateUpdated");
        }
    }
}
