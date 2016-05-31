namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateQueuesAndCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Queues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QueueId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        NumberInParty = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 10),
                        UrlToken = c.String(nullable: false, maxLength: 12),
                        DateAdded = c.DateTime(nullable: false),
                        SortOrder = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Queues", t => t.QueueId, cascadeDelete: true)
                .Index(t => t.QueueId);
        }
        
        public override void Down()
        {
            DropForeignKey("Customers", "QueueId", "dbo.Queues");
            DropForeignKey("Queues", "BusinessId", "dbo.Businesses");
            DropIndex("Customers", new[] { "QueueId" });
            DropIndex("Queues", new[] { "BusinessId" });
            DropTable("Customers");
            DropTable("Queues");
        }
    }
}
