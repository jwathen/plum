namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateDeletedToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "DateDeleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("Customers", "DateDeleted");
        }
    }
}
