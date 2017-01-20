namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDeleteCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "DateDeleted", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("Customers", "DateDeleted");
        }
    }
}
