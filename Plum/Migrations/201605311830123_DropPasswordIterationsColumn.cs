namespace Plum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropPasswordIterationsColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("Businesses", "Account_PasswordIterations");
        }
        
        public override void Down()
        {
            AddColumn("Businesses", "Account_PasswordIterations", c => c.Int(nullable: false));
        }
    }
}
