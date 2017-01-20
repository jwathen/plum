namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultValueForCustDateInserted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Customers", "DateAdded", x => x.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
        }
    }
}
