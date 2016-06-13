namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateReadToCustomerLogEntries : DbMigration
    {
        public override void Up()
        {
            AddColumn("CustomerLogEntries", "DateRead", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("CustomerLogEntries", "DateRead");
        }
    }
}
