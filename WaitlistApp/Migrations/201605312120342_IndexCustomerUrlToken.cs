namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexCustomerUrlToken : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Customers", "UrlToken", unique: true, name: "UK_Customers_UrlToken");
        }
        
        public override void Down()
        {
            DropIndex("Customers", "UK_Customers_UrlToken");
        }
    }
}
