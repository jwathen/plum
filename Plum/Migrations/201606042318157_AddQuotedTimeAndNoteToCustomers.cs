namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuotedTimeAndNoteToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "QuotedTimeInMinutes", c => c.Int(nullable: true));
            AddColumn("Customers", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Customers", "Note");
            DropColumn("Customers", "QuotedTimeInMinutes");
        }
    }
}
