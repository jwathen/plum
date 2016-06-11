namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTextMessageLimitsToBusinesses : DbMigration
    {
        public override void Up()
        {
            AddColumn("Businesses", "BillingDate", c => c.DateTime(nullable: true, storeType: "Date"));
            Sql("update Businesses set BillingDate = DateCreated");
            AlterColumn("Businesses", "BillingDate", c => c.DateTime(nullable: false, storeType: "Date"));
            AddColumn("Businesses", "TextMessagesSent", c => c.Int(nullable: false));
            AddColumn("Businesses", "TextMessageLimit", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("Businesses", "TextMessageLimit");
            DropColumn("Businesses", "TextMessagesSent");
            DropColumn("dbousinesses", "BillingDate");
        }
    }
}
