namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBrandJumboImageFromByteToUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("Brands", "JumboImageUrl", c => c.String(unicode: false, maxLength: 1024));
            DropColumn("Brands", "JumboImage");
        }
        
        public override void Down()
        {
            AddColumn("Brands", "JumboImage", c => c.Binary());
            DropColumn("Brands", "JumboImageUrl");
        }
    }
}
