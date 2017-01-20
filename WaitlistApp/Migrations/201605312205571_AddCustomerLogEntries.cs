namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerLogEntries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CustomerLogEntries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    DateInserted = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Message = c.String(),
                    Type = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
        }
        
        public override void Down()
        {
            DropForeignKey("CustomerLogEntries", "CustomerId", "dbo.Customers");
            DropIndex("CustomerLogEntries", new[] { "CustomerId" });
            DropTable("CustomerLogEntries");
        }
    }
}
