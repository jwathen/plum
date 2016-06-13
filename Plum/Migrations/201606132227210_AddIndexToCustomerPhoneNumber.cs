namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToCustomerPhoneNumber : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Customers", "PhoneNumber", name: "IX_Customers_PhoneNumber");
        }
        
        public override void Down()
        {
            DropIndex("Customers", "IX_Customers_PhoneNumber");
        }
    }
}
