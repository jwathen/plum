namespace WaitlistApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecondaryColorToBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("Brands", "SecondaryColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Brands", "SecondaryColor");
        }
    }
}
