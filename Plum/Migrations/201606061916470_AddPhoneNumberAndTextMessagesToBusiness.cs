namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberAndTextMessagesToBusiness : DbMigration
    {
        public override void Up()
        {
            AddColumn("Businesses", "PhoneNumber", c => c.String(maxLength: 10));
            AddColumn("Businesses", "WelcomeTextMessage", c => c.String());
            AddColumn("Businesses", "ReadyTextMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Businesses", "ReadyTextMessage");
            DropColumn("Businesses", "WelcomeTextMessage");
            DropColumn("Businesses", "PhoneNumber");
        }
    }
}
